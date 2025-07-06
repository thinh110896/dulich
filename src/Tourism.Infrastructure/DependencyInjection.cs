using Tourism.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Tourism.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDas(Assembly.GetExecutingAssembly());

        services.AddDbContext<TourismDbContext>(options =>
        {
            var appMigrationAssembly = typeof(TourismDbContext).GetTypeInfo().Assembly.GetName().Name;
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), sql => sql.MigrationsAssembly(appMigrationAssembly));
        });
    }

    public static void MigrationInfrastructure(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<TourismDbContext>();
        dbContext.Database.Migrate();
    }
}
