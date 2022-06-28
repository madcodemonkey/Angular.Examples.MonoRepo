
using Acme.Repositories.Extensions;
using Acme.Services;

namespace TodoWebSite
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAcmeApiDependencies(this IServiceCollection sc, IConfiguration config)
        {
            sc.AddRepositories(options => config.GetSection("DatabaseOptions").Bind(options));

            sc.AddServices();

            return sc;
        }
    }

}
