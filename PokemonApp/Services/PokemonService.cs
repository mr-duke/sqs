using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PokemonApp.Models;
using System.Text.Json;

namespace PokemonApp.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly PokemonDbContext _dbContext;

        public PokemonService(IHttpClientWrapper httpClientWrapper, PokemonDbContext dbContext)
        {
            _httpClientWrapper = httpClientWrapper;
            _dbContext = dbContext;
        }

        public async Task<Pokemon> GetPokemonByIdFromDatabase(int number)
        {
            Pokemon pokemon = new Pokemon();
            pokemon = await _dbContext.Pokemons.FirstOrDefaultAsync(p => p.Number == number);

            return pokemon;

        }

        public async Task<Pokemon> GetPokemonByIdFromAPI(int number)
        {
            Pokemon pokemon = new Pokemon();
            HttpResponseMessage response = await _httpClientWrapper.GetAsync($"https://pokeapi.co/api/v2/pokemon/{number}", HttpCompletionOption.ResponseHeadersRead);
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
