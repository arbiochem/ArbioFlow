using ArbioFlow.Data;
using ArbioFlow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArbioFlow.Services
{
    public class Authentification : IAuthentification
    {
        private readonly ArbioDbContext _arbio;
        private readonly PasswordHasher<UtilisateurArbio> _hasher = new();

        public Authentification(ArbioDbContext arbio)
        {
            _arbio = arbio;
        }

        public async Task<bool> ValiderAsync(string utilisateur, string password)
        {
            if (string.IsNullOrWhiteSpace(utilisateur)) return false;

            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur && x.PasswordHash != null);
            if (u == null || !u.Actif) return false;

            return _hasher.VerifyHashedPassword(u, u.PasswordHash, password)
                   != PasswordVerificationResult.Failed;
        }


        public async Task CreerOuMajAsync(string utilisateur, string password)
        {
            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur);
            if (u == null)
            {
                u = new UtilisateurArbio { Login = utilisateur };
                _arbio.UtilisateursArbio.Add(u);
            }
            u.PasswordHash = _hasher.HashPassword(u, password);
            u.Actif = true;
            u.PendingHash = null;
            u.DateDemande = null;
            await _arbio.SaveChangesAsync();
        }

        public async Task<List<UtilisateurInfo>> ListerAsync()
            => await _arbio.UtilisateursArbio
                .OrderBy(u => u.Actif && u.PendingHash == null)
                .ThenBy(u => u.Login)
                .Select(u => new UtilisateurInfo(u.Login, u.Actif, u.PendingHash != null, u.DateDemande))
                .ToListAsync();


        public async Task SupprimerAsync(string utilisateur)
        {
            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur);
            if (u == null) return;
            _arbio.UtilisateursArbio.Remove(u);
            await _arbio.SaveChangesAsync();
        }

        public async Task<string?> DemanderInscriptionAsync(string utilisateur, string password)
        {

            if (await _arbio.UtilisateursArbio.AnyAsync(x => x.Login == utilisateur))
                return "Un compte ou une demande existe déjà pour cet identifiant.";

            var u = new UtilisateurArbio
            {
                Login = utilisateur,
                Actif = false,
                DateDemande = DateTime.Now
            };
            u.PasswordHash = _hasher.HashPassword(u, password);
            _arbio.UtilisateursArbio.Add(u);
            await _arbio.SaveChangesAsync();
            return null;
        }

        public async Task DemanderResetAsync(string utilisateur, string password)
        {
            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur);
            
            u.PendingHash = _hasher.HashPassword(u, password);
            u.DateDemande = DateTime.Now;
            u.Actif = false;
            await _arbio.SaveChangesAsync();
        }

        public async Task ApprouverAsync(string utilisateur)
        {
            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur);
            if (u == null) return;

            if (u.PendingHash != null)
            {
                u.PasswordHash = u.PendingHash;
                u.PendingHash = null;
            }
            u.Actif = true;
            u.DateDemande = null;
            await _arbio.SaveChangesAsync();
        }

        public async Task RefuserAsync(string utilisateur)
        {
            var u = await _arbio.UtilisateursArbio.FirstOrDefaultAsync(x => x.Login == utilisateur);
            if (u == null) return;

            if (!u.Actif) _arbio.UtilisateursArbio.Remove(u);
            else { u.PendingHash = null; u.DateDemande = null; }
            await _arbio.SaveChangesAsync();
        }
    }
}