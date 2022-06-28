using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Acme.Repositories.Extensions;

public static class ServiceProviderExtensions
{
    public static async Task ApplyMigrationsForAcmeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        var connectionsConfig = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>();

        // Should the migration be run?
        if ((connectionsConfig.Value?.RunMigrationsOnStartup ?? false) == false) return;

        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            {
                var dbContext = services.GetRequiredService<AcmeContext>();

                await dbContext.Database.MigrateAsync();

#if DEBUG
                await SeedAcmeDatabase.SeedDataAsync(dbContext);
#endif
            }
        }
    }
}