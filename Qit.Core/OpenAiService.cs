using Qit.Core.Abstractions;
using Qit.Core.Models;

namespace Qit.Core
{
    internal sealed class OpenAiService(string apiKey, IOpenAiClient openAiClient) : IOpenAiService
    {
        public async Task<IEnumerable<CategoryAttributes>> SendRequest(IEnumerable<Category> categories)
        {
            var flattenCategories = categories.SelectMany(c => c.SubCategories);

            IEnumerable<CategoryAttributes> result = await openAiClient.SendAsync(apiKey, flattenCategories);

            throw new NotImplementedException();
        }
    }
}