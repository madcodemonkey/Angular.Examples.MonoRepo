using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Acme.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, Action<DatabaseOptions> databaseOptions)
    {
        services.Configure<DatabaseOptions>(databaseOptions);

        _ = services.AddDbContext<AcmeContext>((serviceProvider, options) =>
        {
            var connections = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
            options.UseSqlServer(connections?.Value?.AcmeDbConnection ?? string.Empty, sqlServerOptions =>
            {
                sqlServerOptions.MigrationsAssembly(typeof(AcmeContext).Assembly.FullName);
            });
        });

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        
        return services;
    }
}