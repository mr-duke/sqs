using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Tests
{
    public class PokemonTests
    {
        [Fact]
        public void PokemonConstructor_ValidArguments_ShouldCreatePokemon()
        {
            // Arrange
            int number = 1;
            string name = "Bulbasaur";
            string type1 = "Grass";
            string type2 = "Poison";
            string imageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png";

            // Act
            var pokemon = new Pokemon(number, name, type1, type2, imageUrl);

            // Assert
            Assert.Equal(number, pokemon.Number);
            Assert.Equal(name, pokemon.Name);
            Assert.Equal(type1, pokemon.Type1);
            Assert.Equal(type2, pokemon.Type2);
            Assert.Equal(imageUrl, pokemon.ImageUrl);
        }
    }
}
