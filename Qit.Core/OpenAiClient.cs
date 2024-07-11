using OpenAI_API;
using OpenAI_API.Models;
using Qit.Core.Abstractions;
using Qit.Core.Models;

namespace Qit.Core
{
    public class OpenAiClient : IOpenAiClient
    {
        public async Task<IEnumerable<CategoryAttributes>> SendAsync(string apiKey, IEnumerable<SubCategory> category)
        {
            var api = new OpenAIAPI(apiKey);

            var chat = api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;
            chat.RequestParameters.Temperature = 0;

            throw new NotImplementedException();
        }
    }
}