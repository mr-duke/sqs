using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using PokemonApp.Models;
using Moq;
using PokemonApp.Services;

namespace PokemonApp.Tests
{
    public class PokemonServiceTests
    {
        //private readonly HttpClient _httpClient = new HttpClient();
        private DbContextOptions<PokemonDbContext> _dbContextOptions;

        public PokemonServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PokemonDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task GetPokemonAsync_ReturnsPokemonFromDatabase_WhenPokemonExists()
        {
            // Arrange
            using (var dbContext = new PokemonDbContext(_dbContextOptions))
            {
                // Seed the database with a Pokemon
                var pokemon = new Pokemon
                {
                    Name = "Bulbasaur",
                    Number = 1,
                    Type1 = "Grass",
                    Type2 = "Poison",
                    ImageUrl = "https://pokeapi.co/api/v2/pokemon/1/"
                };
                dbContext.Pokemons.Add(pokemon);
                await dbContext.SaveChangesAsync();
            }

            var httpClientMock = new Mock<IHttpClientWrapper>();
            var service = new PokemonService(httpClientMock.Object, new PokemonDbContext(_dbContextOptions));

            // Act
            var result = await service.GetPokemonByIdFromDatabase(1);

            // Assert
            Assert.Equal(1, result.Number);
            Assert.Equal("Bulbasaur", result.Name);
            Assert.Equal("Grass", result.Type1);
            Assert.Equal("Poison", result.Type2);
            Assert.Equal("https://pokeapi.co/api/v2/pokemon/1/", result.ImageUrl);
        }

        [Fact]
        public async Task GetPokemonAsync_RetrievesPokemonFromPokeapi_WhenPokemonDoesNotExistInDatabase()
        {
            // Arrange
            var httpClientMock = new Mock<IHttpClientWrapper>();
            httpClientMock.Setup(c => c.GetAsync(It.IsAny<string>(), HttpCompletionOption.ResponseHeadersRead))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    // Reflect structure of PokeAPI
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        name = "bulbasaur",
                        id = 1,    
                        sprites = new
                        {
                            front_default = "https://pokeapi.co/api/v2/pokemon/1/"
                        },
                        types = new[]
                        {
                            new { type = new { name = "grass" } },
                            new { type = new { name = "poison" } }
                        }
                    }))
                });

        using (var dbContext = new PokemonDbContext(_dbContextOptions))
        {
            var service = new PokemonService(httpClientMock.Object, dbContext);

            // Act
            var result = await service.GetPokemonByIdFromAPI(1);

            // Assert
            Assert.Equal(1, result.Number);
            Assert.Equal("Bulbasaur", result.Name);
            Assert.Equal("Grass", result.Type1);
            Assert.Equal("Poison", result.Type2);
            Assert.Equal("https://pokeapi.co/api/v2/pokemon/1/", result.ImageUrl);
            }
        }

    }
}