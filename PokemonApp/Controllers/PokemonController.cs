using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonApp.Services;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IMemoryCache _cache;
        private readonly PokemonService _pokemonService;

        public PokemonController(ILogger<PokemonController> logger, IMemoryCache cache, PokemonService pokemonService)
        {
            _logger = logger;
            _cache = cache;
            _pokemonService = pokemonService;
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int number)
        {
            Pokemon pokemon = new Pokemon();
            // First, check if the Pokemon is already in the database
            pokemon = await _pokemonService.GetPokemonByIdFromDatabase(number);
            // If not, query the PokeAPI for the Pokemon data
            if (pokemon == null)
            {
                pokemon = await _pokemonService.GetPokemonByIdFromAPI(number);
                if (pokemon == null)
                {
                    return NotFound();
                }
            }
            return pokemon;
        }
    }
}