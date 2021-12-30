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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
        }
    }
}