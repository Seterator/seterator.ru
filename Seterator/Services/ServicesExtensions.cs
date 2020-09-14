using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Seterator.Services
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Добавляет в коллекцию сервисов все сервисы связанные с бизнес-логикой приложения.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services
                .AddHashService()
                .AddAuthService()
                .AddAccountService()
                .AddCurrentUserService();
        }

        public static IServiceCollection AddHashService(this IServiceCollection services)
        {
            return services.AddSingleton(new HashService());
        }

        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            return services.AddScoped<AuthService>();
        }
        public static IServiceCollection AddAccountService(this IServiceCollection services)
        {
            return services.AddScoped<AccountService>();
        }

        public static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            return services.AddScoped<CurrentUserService>();
        }
    }
}
