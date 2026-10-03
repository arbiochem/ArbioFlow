using ArbioFlow.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ArbioFlow.Data;

public class ArbioDbContext : DbContext
{
    public ArbioDbContext(DbContextOptions<ArbioDbContext> options) : base(options) { }

    public DbSet<UtilisateurArbio> UtilisateursArbio { get; set; }
    public DbSet<HistoriqueValidationDto> HistoriqueValidations { get; set; }
    public DbSet<LivraisonFacture> LivraisonFactures => Set<LivraisonFacture>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<UtilisateurArbio>(e =>
        {
            e.ToTable("UtilisateurArbio");
            e.HasKey(u => u.Id);
            e.HasIndex(u => u.Login).IsUnique();
        });

        mb.Entity<HistoriqueValidationDto>(e =>
        {
            e.ToTable("HistoriqueValidation");
            e.HasKey(x => x.Id);
            e.Property(x => x.DoPiece).HasMaxLength(20).IsRequired();
            e.Property(x => x.ArRef).HasMaxLength(30).IsRequired();
            e.Property(x => x.Designation).HasMaxLength(250).IsRequired();
            e.Property(x => x.Validateur).HasMaxLength(100).IsRequired();
            e.Property(x => x.QteValidee).HasPrecision(18, 3);
            e.Property(x => x.Depot);
            e.HasIndex(x => x.DoPiece);
        });

        mb.Entity<LivraisonFacture>(e =>
        {
            e.ToTable("LivraisonFacture");
            e.HasKey(x => x.Id);

            e.Property(x => x.DoPiece).HasMaxLength(20).IsRequired();
            e.HasIndex(x => x.DoPiece).IsUnique();          // une seule ligne par facture

            e.Property(x => x.TypeFacture).HasMaxLength(50);
            e.Property(x => x.TypeRetrait).HasMaxLength(50);
            e.Property(x => x.Vehicule).HasMaxLength(30);
            e.Property(x => x.Chauffeur).HasMaxLength(100);
            e.Property(x => x.StatutPrep).HasMaxLength(30);
            e.Property(x => x.CauseNonTransfert).HasMaxLength(100);
            e.Property(x => x.Observations).HasMaxLength(2000);
            e.Property(x => x.ModifiePar).HasMaxLength(100);

            e.Property(x => x.DateLivraison).HasColumnType("date");
            e.Property(x => x.DateDebutPrep).HasColumnType("date");
            e.Property(x => x.HeureDebutPrep).HasColumnType("time(0)");
        });
    }
}