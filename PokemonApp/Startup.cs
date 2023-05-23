using Microsoft.EntityFrameworkCore;
using PokemonApp.Models;
using PokemonApp.Services;

namespace PokemonApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddSingleton(configuration);

            services.AddDbContext<PokemonDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PokemonDB")));

            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient<IPokemonService>();
            //builder.Services.AddScoped<PokemonService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();

            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
