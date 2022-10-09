using MediatR;
using Npgsql;
using VolNal.Chat.AuthorizationService.Infrastructure.Factories;
using VolNal.Chat.AuthorizationService.Infrastructure.Factories.Interfaces;
using VolNal.Chat.AuthorizationService.Infrastructure.Mapping;
using VolNal.Chat.AuthorizationService.Repositories.Implementation;
using VolNal.Chat.AuthorizationService.Repositories.Interfaces;

namespace VolNal.Chat.AuthorizationService;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        #region DataBase

        services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
        services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        services.AddMediatR(typeof(Startup));
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}