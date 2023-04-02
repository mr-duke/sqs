using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PokemonApp;
using PokemonApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add database configuration

builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PokemonDB")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<PokemonService>();
builder.Services.AddScoped<PokemonService>();


// Add caching configuration
builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
