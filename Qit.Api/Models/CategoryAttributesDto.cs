using System.Text.Json.Serialization;

namespace Qit.Api.Models
{
    public class CategoryAttributesDto
    {
        [JsonPropertyName("categoryId")]
        public long CategoryId { get; set; }

        [JsonPropertyName("attributes")]
        public string[] Attributes { get; set; }
    }
}
