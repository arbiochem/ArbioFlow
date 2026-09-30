using ArbioFlow.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class AdminController : Controller
{
    private readonly ArbioDbContext _db;
    public AdminController(ArbioDbContext db) => _db = db;

    public async Task<IActionResult> Demandes()
    {
        var demandes = await _db.UtilisateursArbio
            .Where(u => !u.Actif && u.PendingHash != null)
            .OrderBy(u => u.DateDemande)
            .ToListAsync();
        return View(demandes);
    }

    public async Task<IActionResult> Validations()
    {
        var validations = await _db.UtilisateursArbio
            .Where(u => !u.Actif && u.PendingHash == null)
            .OrderBy(u => u.DateDemande)
            .ToListAsync();
        return View(validations);
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Approuver(int id)
    {
        var u = await _db.UtilisateursArbio.FindAsync(id);
        if (u?.PendingHash != null)
        {
            u.PasswordHash = u.PendingHash;   // le mot de passe demandé devient officiel
            u.PendingHash = null;
            u.Actif = true;
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Demandes));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Valider(int id)
    {
        var u = await _db.UtilisateursArbio.FindAsync(id);

        u.Actif = true;
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Validations));
    }
}