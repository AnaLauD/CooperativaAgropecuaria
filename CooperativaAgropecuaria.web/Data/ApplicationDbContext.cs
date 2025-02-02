using CooperativaAgropecuaria.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAgropecuaria.web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Maquinaria> Maquinarias { get; set; }
        public DbSet<UsoMaquinaria> UsosMaquinaria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsoMaquinaria>()
                .HasOne(um => um.Maquinaria)
                .WithMany(m => m.UsosMaquinaria)
                .HasForeignKey(um => um.MaquinariaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsoMaquinaria>()
                .HasOne(um => um.Agricultor)
                .WithMany(a => a.UsosMaquinaria)
                .HasForeignKey(um => um.AgricultorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }

}
