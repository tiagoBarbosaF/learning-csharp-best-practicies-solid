using Microsoft.EntityFrameworkCore;
using LeilaoOnline.WebApp.Models;

namespace LeilaoOnline.WebApp.Dados
{
    public class AppDbContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LeiloesDb;User ID=sa;Password=<@CourseSolid@>");
            // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AluraLeiloesDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Leiloes)
                .HasForeignKey(l => l.IdCategoria);
        }
    }
}