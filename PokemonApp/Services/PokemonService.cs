using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PokemonApp.Models;
using System.Text.Json;

namespace PokemonApp.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;
        private readonly PokemonDbContext _dbContext;

        public PokemonService(HttpClient httpClient, PokemonDbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<Pokemon> GetPokemon(int number)
        {
            Pokemon pokemon = new Pokemon();
            // First, check if the Pokemon is already in the database
            pokemon = await _dbContext.Pokemons.FirstOrDefaultAsync(p => p.Number == number);
            if (pokemon != null)
            {
                return pokemon;
            }

            // If not, query the PokeAPI for the Pokemon data
            HttpResponseMessage response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{number}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            PokemonDTO dto = new PokemonDTO(response);

            pokemon = new Pokemon
            {
                Number = dto.Number,
                Name = dto.Name,
                Type1 = dto.Type1,
                Type2 = dto.Type2,
                ImageUrl = dto.ImageUrl,
                //Description = dto.Description
            };

            // Add the Pokemon to the database for caching
            _dbContext.Pokemons.Add(pokemon);
            await _dbContext.SaveChangesAsync();

            return pokemon;
        }
    }
}
