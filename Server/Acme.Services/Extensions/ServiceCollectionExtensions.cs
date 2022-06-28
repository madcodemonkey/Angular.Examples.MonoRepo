using Microsoft.Extensions.DependencyInjection;

namespace Acme.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection sc)
        {
            sc.AddScoped<ITodoService, TodoService>();

            return sc;
        }
    }

}
