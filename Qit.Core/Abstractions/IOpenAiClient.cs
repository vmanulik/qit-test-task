using Qit.Core.Models;

namespace Qit.Core.Abstractions
{
    public interface IOpenAiClient
    {
        Task<IEnumerable<CategoryAttributes>> SendAsync(string apiKey, IEnumerable<SubCategory> category);
    }
}