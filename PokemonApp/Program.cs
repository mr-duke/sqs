using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PokemonApp;
using PokemonApp.Models;
using PokemonApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program 
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}
