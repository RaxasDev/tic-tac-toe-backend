using Domain.Interfaces;
using Infrastructure.Repositories.EF;

namespace Api.Config;

public static class DependencyInjectionConfiguration
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        }
    }