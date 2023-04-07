using PokemonApp.Models;
using System.Net;

namespace PokemonApp.Tests
{
    public class PokemonDTOTests
    {
        [Fact]
        public void PokemonDTO_ParseResponseMessage_ShouldReturnValidAndFormattedPokemonDTO()
        {
            // Arrange
            string responseContent = "{\"name\":\"charmander\",\"id\":4,\"sprites\":{\"front_default\":\"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png\"},\"types\":[{\"type\":{\"name\":\"fire\",\"url\":\"https://pokeapi.co/api/v2/type/10/\"}}]}";
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent)
            };

            // Act
            PokemonDTO pokemonDTO = new PokemonDTO(responseMessage);

            // Assert
            Assert.Equal("Charmander", pokemonDTO.Name);
            Assert.Equal(4, pokemonDTO.Number);
            Assert.Equal("Fire", pokemonDTO.Type1);
            Assert.Equal("None", pokemonDTO.Type2);
            Assert.Equal("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png", pokemonDTO.ImageUrl);
        }
    }
 }
