using ArbioFlow.Data;
using ArbioFlow.Models;
using ArbioFlow.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;

namespace ArbioFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPreparation _preparation;
        private readonly IAuthentification _auth;
        private readonly IConfiguration _cfg;
        private readonly ArbioDbContext _db;
        private readonly IPasswordHasher<UtilisateurArbio> _hasher;

        public HomeController(ILogger<HomeController> logger, IPreparation preparation, IAuthentification auth,ArbioDbContext db, IPasswordHasher<UtilisateurArbio> hasher)
        {
            _logger = logger;
            _preparation = preparation;
            _auth = auth;
            _db = db;
            _hasher = hasher;
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime? dateDebut, DateTime? dateFin, String? q)
        {
            ViewBag.dateDebut = dateDebut;
            ViewBag.dateFin = dateFin;
            ViewBag.q = q;

            var requete = await _preparation.getPreparation(dateDebut, dateFin, q);
            return View(requete);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private static bool MotsDePasseIdentiques(string a, string b)
        {
            var x = System.Text.Encoding.UTF8.GetBytes(a);
            var y = System.Text.Encoding.UTF8.GetBytes(b);
            return System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(x, y);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string utilisateur, string password)
        {
            utilisateur = utilisateur?.Trim() ?? "";
            ViewBag.utilisateur = utilisateur;

            if (!await _auth.ValiderAsync(utilisateur, password ?? ""))
            {
                ViewBag.Erreur = "Identifiant ou mot de passe incorrect ou Compte pas encore validé";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, utilisateur)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }
        }

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
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Inscription() => View();

        [HttpPost, ValidateAntiForgeryToken,AllowAnonymous]
        public async Task<IActionResult> Inscription(string utilisateur, string password, string confirmation, InscriptionViewModel model)
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

            var user = new UtilisateurArbio
            {
                Login = model.Login,
                Actif = false,
                DateDemande = DateTime.Now
            };
            user.PendingHash = _hasher.HashPassword(user, model.MotDePasse);

            _db.UtilisateursArbio.Add(user);
            await _db.SaveChangesAsync();

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
    }
}
