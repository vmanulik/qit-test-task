using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Qit.Core.Abstractions;
using Qit.Core.Models;
using System.Text;

namespace Qit.Core
{
    public class OpenAiClient : IOpenAiClient
    {
        public async Task<IEnumerable<CategoryAttributes>> SendAsync(string apiKey, int maxTokens, IEnumerable<SubCategory> category)
        {
            var api = new OpenAIAPI(apiKey);

            // request output format in JSON
            var chatRequest = new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 1.0,
                MaxTokens = maxTokens,
                // but not use response format as it does not work that easily
                //ResponseFormat = ChatRequest.ResponseFormats.JsonObject,
                Messages = [
                    new ChatMessage(ChatMessageRole.System, "You are a helpful assistant designed to output JSON."),
                ]
            };

            // give an example of required output format
            chatRequest.Messages.Add(
                new ChatMessage(
                    ChatMessageRole.User,
                    "Here is an example of output json format i will expext to get from you:\r\n[\r\n  {\r\n    \"categoryId\": 80,\r\n    \"attributes\": [ \"attribute1\", \"attribute2\", \"attribute3\" ]\r\n  },\r\n  {\r\n    \"categoryId\": 948,\r\n    \"attributes\": [ \"attribute4\", \"attribute5\", \"attribute6\" ]\r\n  }\r\n]\r\n\"categoryId\" is related to the same property in my further questions. Whole json is an array without a root node. It is important to use only this format!")
                 );

            // build the request
            var builder = new StringBuilder("Give a list of the most popular attributes \r\nfor such products as ");
            
            int counter = category.Count();
            foreach(var subCategory in category)
            {
                builder.Append($"\"{subCategory.CategoryName}\" with \"categoryId\": {subCategory.CategoryId}");

                // do not append "and" to the last row
                if (counter > 1) builder.Append(" and ");
                counter--;
            }

            chatRequest.Messages.Add(new ChatMessage(ChatMessageRole.User, builder.ToString()));

            try
            {
                var results = await api.Chat.CreateChatCompletionAsync(chatRequest);

                string json = results.ToString();
                IEnumerable<CategoryAttributes>? attributes = JsonConvert.DeserializeObject<IEnumerable<CategoryAttributes>>(json);

                return attributes;
            }
            catch (Exception ex)
            {
                throw new Exception("You never know what this chat model will do out of the blue", ex);
            }
            
        }
    }
}