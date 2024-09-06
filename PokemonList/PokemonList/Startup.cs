using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokemonList.Data;
using PokemonList.Services;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configurar o Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Pokémon API",
                Version = "v1"
            });
        });

        // Configurar o banco de dados
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=pokemonlist.db")); // Ou a string de conexão apropriada

        // Registrar o HttpClient e o PokeApiService
        services.AddHttpClient<PokeApiService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokémon API v1");
            c.RoutePrefix = string.Empty; // Swagger na raiz
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Mapeia os endpoints dos controllers
        });
    }
}
