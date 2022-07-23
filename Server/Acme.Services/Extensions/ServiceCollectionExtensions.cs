using Microsoft.Extensions.DependencyInjection;

namespace Acme.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection sc)
        {            
            sc.AddScoped<ICountryService, CountryService>();
            sc.AddScoped<IPeopleService, PeopleService>();
            sc.AddScoped<IStateService, StateService>();
            sc.AddScoped<ITodoService, TodoService>();
            sc.AddScoped<IToolReportService, ToolReportService>();
            sc.AddScoped<IZipService, ZipService>();

            return sc;
        }
    }

}
