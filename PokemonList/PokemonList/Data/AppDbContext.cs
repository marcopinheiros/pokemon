using Microsoft.EntityFrameworkCore;
using PokemonList.Models;

namespace PokemonList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Master> Masters { get; set; }

        public DbSet<CapturedPokemon> CapturedPokemons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Master>().ToTable("Masters");
            modelBuilder.Entity<CapturedPokemon>().ToTable("CapturedPokemon");
        }
    }
}
