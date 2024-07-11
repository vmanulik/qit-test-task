using Microsoft.Extensions.DependencyInjection;
using Qit.Core.Abstractions;

namespace Qit.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOpenAiServices(this IServiceCollection services, string apiKey)
        {
            services.AddScoped<IOpenAiClient, OpenAiClient>();
            services.AddScoped<IOpenAiService, OpenAiService>(serviceProvider => new OpenAiService(apiKey, serviceProvider.GetRequiredService<IOpenAiClient>()));
        }
    }
}

