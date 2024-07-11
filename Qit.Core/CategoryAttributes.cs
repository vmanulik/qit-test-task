using System.Text.Json.Serialization;

namespace Qit.Core
{
    public class CategoryAttributes
    {
        [JsonPropertyName("categoryId")]
        public long CategoryId { get; set; }

        [JsonPropertyName("attributes")]
        public string[] Attributes { get; set; }
    }
}
