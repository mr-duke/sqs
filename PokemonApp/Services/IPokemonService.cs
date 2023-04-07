using PokemonApp.Models;

namespace PokemonApp.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemonByIdFromAPI(int number);
        Task<Pokemon> GetPokemonByIdFromDatabase(int number);
    }
}