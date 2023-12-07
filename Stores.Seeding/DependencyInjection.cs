using Microsoft.Extensions.DependencyInjection;

namespace Stores.Seeding;

public static class DependencyInjection
{
    public static void AddSeeder(this IServiceCollection services)
    {
        services.AddScoped<Seeder>();
    }
}