using ArbioFlow.Data;
using ArbioFlow.Models;
using ArbioFlow.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ArbioFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPreparation _preparation;
        private readonly IValiderLigne _validerLigne;
        private readonly IAuthentification _auth;
        private readonly ArbioDbContext _db;
        private readonly IPasswordHasher<UtilisateurArbio> _hasher;

        public HomeController(
            ILogger<HomeController> logger,
            IPreparation preparation,
            IAuthentification auth,
            ArbioDbContext db,
            IValiderLigne validerLigne,
            IPasswordHasher<UtilisateurArbio> hasher)
        {
            _logger = logger;
            _preparation = preparation;
            _auth = auth;
            _db = db;
            _hasher = hasher;
            _validerLigne = validerLigne;
        }

        // Dépôt de l'utilisateur connecté, lu depuis le claim (jamais depuis le client)
        private int DepotCourant =>
            int.TryParse(User.FindFirst("DeNo")?.Value, out var d) ? d : 0;

        // ---------- Préparation ----------
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime? dateDebut, DateTime? dateFin, string? q)
        {
            ViewBag.dateDebut = dateDebut;
            ViewBag.dateFin = dateFin;
            ViewBag.q = q;

            var requete = await _preparation.getPreparation(dateDebut, dateFin, q, DepotCourant);
            return View(requete);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string doPiece)
        {
            var lignes = await _preparation.GetLignesAsync(doPiece);

            ViewData["DoPiece"] = doPiece;
            ViewData["Validateur"] = User.Identity?.Name ?? "";
            //ViewData["Historique"] = await _validerLigne.GetHistoriqueAsync(doPiece);

            return PartialView("_LignesFacture", lignes);
        }

        // ValiderLigneRequest est défini dans ArbioFlow.Models (Models/ValiderLigneRequest.cs)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValiderLigne([FromBody] ValiderLigneRequest req)
        {
            if (req == null
                || string.IsNullOrWhiteSpace(req.DoPiece)
                || string.IsNullOrWhiteSpace(req.ArRef))
                return BadRequest("Données incomplètes.");

            if (req.QtePreparee < 0)
                return BadRequest("Quantité invalide.");

            var resultat = await _validerLigne.ValiderLigneAsync(
                req.DoPiece,
                req.ArRef,
                req.QtePreparee,
                req.Designation,
                User.Identity?.Name ?? "",
                DepotCourant);

            return resultat.Succes
                ? Ok(resultat)
                : BadRequest(resultat.Message);
        }

        // ---------- Authentification ----------
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            ViewBag.Depots = await _auth.ChargerDepots();
            return View();
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string utilisateur, string password, int depot)
        {
            utilisateur = utilisateur?.Trim() ?? "";
            ViewBag.utilisateur = utilisateur;
            ViewBag.depot = depot.ToString();   // string : ton <select> compare avec "as string"
            ViewBag.Depots = await _auth.ChargerDepots();

            if (!await _auth.ValiderAsync(utilisateur, password ?? ""))
            {
                ViewBag.Erreur = "Identifiant ou mot de passe incorrect ou Compte pas encore validé";
                return View();
            }

            var dep = await _auth.recupDepot(depot);
            if (dep == null)
            {
                ViewBag.Erreur = "Dépôt introuvable";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utilisateur),
                new Claim("DeNo", dep.DeNo.ToString()),
                new Claim("DeIntitule", dep.DeIntitule ?? "")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        // ---------- Gestion des accès ----------
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Enregistrer(string utilisateur, string password)
        {
            if (string.IsNullOrWhiteSpace(utilisateur) || string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                TempData["Erreur"] = "Identifiant requis et mot de passe d'au moins 6 caractères.";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await _auth.CreerOuMajAsync(utilisateur.Trim(), password);
                TempData["Ok"] = $"Mot de passe enregistré pour {utilisateur}.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Erreur"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Approuver(string utilisateur)
        {
            await _auth.ApprouverAsync(utilisateur);
            TempData["Ok"] = $"Demande de {utilisateur} approuvée.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Refuser(string utilisateur)
        {
            await _auth.RefuserAsync(utilisateur);
            TempData["Ok"] = $"Demande de {utilisateur} refusée.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Supprimer(string utilisateur)
        {
            if (string.Equals(utilisateur, User.Identity?.Name, StringComparison.OrdinalIgnoreCase))
            {
                TempData["Erreur"] = "Vous ne pouvez pas supprimer votre propre accès.";
            }
            else
            {
                await _auth.SupprimerAsync(utilisateur);
                TempData["Ok"] = $"Accès de {utilisateur} supprimé.";
            }
            return RedirectToAction(nameof(Index));
        }

        // ---------- Inscription ----------
        [HttpGet, AllowAnonymous]
        public IActionResult Inscription() => View();

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Inscription(string utilisateur, string password, string confirmation)
        {
            utilisateur = utilisateur?.Trim() ?? "";
            ViewBag.utilisateur = utilisateur;

            if (utilisateur == "" || string.IsNullOrEmpty(password) || password.Length < 6)
            {
                ViewBag.Erreur = "Identifiant requis et mot de passe d'au moins 6 caractères.";
                return View();
            }
            if (password != confirmation)
            {
                ViewBag.Erreur = "Les mots de passe ne correspondent pas.";
                return View();
            }

            var erreur = await _auth.DemanderInscriptionAsync(utilisateur, password);
            if (erreur != null)
            {
                ViewBag.Erreur = erreur;
                return View();
            }

            TempData["Ok"] = "Demande envoyée. Vous pourrez vous connecter après validation par un administrateur.";
            return RedirectToAction(nameof(Login));
        }

        // ---------- Mot de passe oublié ----------
        [AllowAnonymous, HttpGet]
        public IActionResult MotDePasseOublie() => View();

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> MotDePasseOublie(string utilisateur, string password, string confirmation)
        {
            utilisateur = utilisateur?.Trim() ?? "";
            ViewBag.utilisateur = utilisateur;

            if (utilisateur == "" || string.IsNullOrEmpty(password) || password.Length < 6)
            {
                ViewBag.Erreur = "Identifiant requis et mot de passe d'au moins 6 caractères.";
                return View();
            }
            if (password != confirmation)
            {
                ViewBag.Erreur = "Les mots de passe ne correspondent pas.";
                return View();
            }

            await _auth.DemanderResetAsync(utilisateur, password);

            TempData["Ok"] = "Si l'identifiant existe, votre demande a été transmise à l'administrateur. Votre ancien mot de passe reste valable jusqu'à validation.";
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}