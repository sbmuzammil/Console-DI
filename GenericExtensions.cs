using Microsoft.Extensions.DependencyInjection;

namespace Console_DI
{
    public static class GenericExtensions
    {
        public static void UseStartup<T>(this IServiceCollection services) where T : class
        {
            services.AddTransient<T>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            dynamic startup = scope.ServiceProvider.GetRequiredService<T>();
            startup.ConfigureServices(services);
        }
    }

}
