using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Seterator.Services
{
    public static class ServicesExtensions
    {
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
    }
}
