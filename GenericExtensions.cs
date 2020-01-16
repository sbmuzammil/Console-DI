using Microsoft.Extensions.DependencyInjection;

namespace Console_DI
{
    public static class GenericExtensions
    {
        public static void UseStartup<T>(this IServiceCollection services) where T : class
        {
            services.AddTransient<Startup>();
            using (var provider = services.BuildServiceProvider())
            {
                using (var scope = provider.CreateScope())
                {
                    dynamic starup = scope.ServiceProvider.GetRequiredService<Startup>();
                    starup.ConfigureServices(services);
                }
            }
        }
    }

}
