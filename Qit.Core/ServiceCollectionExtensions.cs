using Microsoft.Extensions.DependencyInjection;
using Qit.Core.Abstractions;

namespace Qit.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOpenAiServices(this IServiceCollection services, string apiKey)
        {
            services.AddScoped<IOpenAiService, OpenAiService>(serviceProvider => new OpenAiService(apiKey));

            //services.AddTransient(serviceProvider => new TokenService(serviceProvider.GetRequiredService<UserManager<IdentityUser>>(), serviceProvider.GetRequiredService<ApplicationDbContext>(), "hello"));
        }
    }
}

