using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace api.Models
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
             : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Tile> Tiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Tile>().ToTable("Tile");

            modelBuilder.Entity<Player>().HasData(
                new Player{Name = "Larsson", Color = "#665758", prevAttack=DateTime.UtcNow}
            );

            modelBuilder.Entity<Tile>().HasData(
                new Tile {Id = 1, ownerId = "Larsson", color="#fcba03"},
                new Tile {Id = 2, ownerId = "Larsson", color="#fc4e03"},
                new Tile {Id = 3, ownerId = "Larsson", color="#035afc"},
                new Tile {Id = 4, ownerId = "Larsson", color="#c203fc"},
                new Tile {Id = 5, ownerId = "Larsson", color="#691c46"},
                new Tile {Id = 6, ownerId = "Larsson", color="#2f732f"},
                new Tile {Id = 7, ownerId = "Larsson", color="#5a947f"},
                new Tile {Id = 8, ownerId = "Larsson", color="#bf7ca1"},
                new Tile {Id = 9, ownerId = "Larsson", color="#de142c"},
                new Tile {Id = 10, ownerId = "Larsson", color="#665758"}
            );
  
        }
    }
}