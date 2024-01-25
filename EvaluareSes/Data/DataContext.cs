using EvaluareSes.Models;
using EvaluareSes.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluareSes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Carti> Carti { get; set; }
        public DbSet<Autori> Autori { get; set; }
        public DbSet<AutoriCarti> AutoriCarti { get; set; }
        public DbSet<Editura> Editura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carti>()
                .HasKey(a => a.CodCarte);
            modelBuilder.Entity<Autori>()
                .HasKey(d => d.CodAutor);
            modelBuilder.Entity<Editura>()
                .HasKey(da => da.CodEditura);

            //many to many
            modelBuilder.Entity<AutoriCarti>()
                .HasKey(ap => new { ap.CodCarte, ap.CodAutor });

            modelBuilder.Entity<AutoriCarti>()
                .HasOne(a => a.Carti)
                .WithMany(ap => ap.AutoriCarti)
                .HasForeignKey(p => p.CodCarte);

            modelBuilder.Entity<AutoriCarti>()
                .HasOne(a => a.Autori)
                .WithMany(ap => ap.AutoriCarti)
                .HasForeignKey(p => p.CodAutor);

        }
    }
}
