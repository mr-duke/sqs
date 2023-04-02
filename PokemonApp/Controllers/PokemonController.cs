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
            if (!_cache.TryGetValue(number, out Pokemon pokemon))
            {
                pokemon = await _pokemonService.GetPokemon(number);
                if (pokemon == null)
                {
                    return NotFound();
                }

                _cache.Set(number, pokemon);
            }

            return pokemon;
        }
    }
}