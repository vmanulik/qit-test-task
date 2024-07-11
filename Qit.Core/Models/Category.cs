using System.Text.Json.Serialization;

namespace Qit.Core.Models
{
    public class Category
    {
        public string CategoryName { get; set; }

        public SubCategory[] SubCategories { get; set; }
    }

    public class SubCategory
    {
        public long CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
