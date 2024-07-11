using System.Text.Json.Serialization;

namespace Qit.Core
{
    public class Category
    {
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("subCategories")]
        public SubCategory[] SubCategories { get; set; }
    }

    public class SubCategory
    {
        [JsonPropertyName("categoryId")]
        public long CategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
    }
}
