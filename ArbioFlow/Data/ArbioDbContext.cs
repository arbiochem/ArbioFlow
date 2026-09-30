using ArbioFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace ArbioFlow.Data;

public class ArbioDbContext : DbContext
{
    public ArbioDbContext(DbContextOptions<ArbioDbContext> options) : base(options) { }

    public DbSet<UtilisateurArbio> UtilisateursArbio { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<UtilisateurArbio>(e =>
        {
            e.ToTable("UtilisateurArbio");
            e.HasKey(u => u.Id);
            e.HasIndex(u => u.Login).IsUnique();
        });
    }
}