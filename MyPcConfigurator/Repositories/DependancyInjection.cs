using MyPcConfigurator.Abstractions;

namespace MyPcConfigurator.Repositories
{
    public static class DependancyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBuildsRepository, BuildsRepository>();
            services.AddScoped<IVendorsRepository, VendorsRepository>();
            services.AddScoped<IPartsRepository, PartsRepository>();
        }
    }
}
