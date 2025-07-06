using Tourism.Domain.Helpers;
using Tourism.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace Tourism.Application;

public static class DependencyInjection
{
    public static void AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddServices(Assembly.GetExecutingAssembly());
    }

    public static void RunMigrations(this IServiceProvider service)
    {
        service.MigrationInfrastructure();
    }
}
