using Microsoft.EntityFrameworkCore;

namespace PokemonApp.Models
{
    public class PokemonDbContext : DbContext
    {
        private readonly string _connectionString;

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Pokemon>().ToTable("Pokemon");
        }
    }

}
