using Qit.Core.Abstractions;
using Qit.Core.Models;

namespace Qit.Core
{
    internal sealed class OpenAiService(string apiKey) : IOpenAiService
    {
        public async Task<IEnumerable<CategoryAttributes>> SendRequest(IEnumerable<Category> categories)
        {
            var client = new OpenAiClient();
            IEnumerable<CategoryAttributes> result = await client.SendAsync(apiKey, categories);

            throw new NotImplementedException();
        }
    }
}