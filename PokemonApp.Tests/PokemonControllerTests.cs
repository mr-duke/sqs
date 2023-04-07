using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonApp.Controllers;
using PokemonApp.Models;
using PokemonApp.Services;

namespace PokemonApp.Tests
{
    public class PokemonControllerTests
    {
        private readonly Mock<IPokemonService> _pokemonServiceMock;

        public PokemonControllerTests()
        {
            _pokemonServiceMock = new Mock<IPokemonService>();
        }

        [Fact]
        public async Task GetPokemon_ReturnsOK_WhenPokemonExists_InDatabase()
        {
            // Arrange
            var pokemon = new Pokemon { Id = 25, Name = "Pikachu" };
            _pokemonServiceMock.Setup(x => x.GetPokemonByIdFromDatabase(25)).ReturnsAsync(pokemon);
            //Logger and cache null because they are not needed for this test
            var controller = new PokemonController(null, null, _pokemonServiceMock.Object);

            // Act
            var result = await controller.GetPokemon(25);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(pokemon, okResult.Value);
        }

        [Fact]
        public async Task GetPokemon_ReturnsOK_WhenPokemonExists_InApi()
        {
            // Arrange
            var pokemon = new Pokemon { Id = 25, Name = "Pikachu" };
            _pokemonServiceMock.Setup(x => x.GetPokemonByIdFromAPI(25)).ReturnsAsync(pokemon);
            //Logger and cache null because they are not needed for this test
            var controller = new PokemonController(null, null, _pokemonServiceMock.Object);

            // Act
            var result = await controller.GetPokemon(25);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(pokemon, okResult.Value);
        }

        [Fact]
        public async Task GetPokemon_ReturnsNotFoundResult_WhenPokemonDoesNotExist_InDatabase()
        {
            // Arrange
            _pokemonServiceMock.Setup(x => x.GetPokemonByIdFromDatabase(25)).ReturnsAsync(null as Pokemon);
            var controller = new PokemonController(null, null, _pokemonServiceMock.Object);

            // Act
            var result = await controller.GetPokemon(25);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetPokemon_ReturnsNotFoundResult_WhenPokemonDoesNotExist_InApi()
        {
            // Arrange
            _pokemonServiceMock.Setup(x => x.GetPokemonByIdFromAPI(25)).ReturnsAsync(null as Pokemon);
            var controller = new PokemonController(null, null, _pokemonServiceMock.Object);

            // Act
            var result = await controller.GetPokemon(25);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

}
