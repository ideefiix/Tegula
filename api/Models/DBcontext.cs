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
                new Player{Name = "Larsson"}
            );

            modelBuilder.Entity<Tile>().HasData(
                new Tile {Id = 1, ownerId = "Larsson"},
                new Tile {Id = 2, ownerId = "Larsson"},
                new Tile {Id = 3, ownerId = "Larsson"},
                new Tile {Id = 4, ownerId = "Larsson"},
                new Tile {Id = 5, ownerId = "Larsson"},
                new Tile {Id = 6, ownerId = "Larsson"},
                new Tile {Id = 7, ownerId = "Larsson"},
                new Tile {Id = 8, ownerId = "Larsson"},
                new Tile {Id = 9, ownerId = "Larsson"},
                new Tile {Id = 10, ownerId = "Larsson"}
            );
  
        }
    }
}