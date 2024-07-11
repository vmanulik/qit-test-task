using System.Text.Json.Serialization;

namespace Qit.Api.Models
{
    public class CategoryDto
    {
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("subCategories")]
        public SubCategoryDto[] SubCategories { get; set; }
    }

    public class SubCategoryDto
    {
        [JsonPropertyName("categoryId")]
        public long CategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
    }
}
