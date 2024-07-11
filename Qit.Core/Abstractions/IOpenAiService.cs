using Qit.Core.Models;

namespace Qit.Core.Abstractions
{
    public interface IOpenAiService
    {
        public Task<IEnumerable<CategoryAttributes>> SendRequest(IEnumerable<Category> request);
    }
}