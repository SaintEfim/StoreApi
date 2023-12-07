using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stores.Application.Common.Behaviors;
using Stores.Application.Interfaces.Repository;
using Stores.Application.Interfaces.Service;
using Stores.Persistence.Repository;
using Stores.Persistence.Service;

namespace Stores.Persistence;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
    }
}