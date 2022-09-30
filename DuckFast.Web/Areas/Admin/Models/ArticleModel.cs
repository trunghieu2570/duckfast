using DuckFast.Database.Entities;

namespace DuckFast.Web.Areas.Admin.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public UserModel? Author { get; set; }
        public string? Slug { get; set; }
        public CategoryModel? Category { get; set; }
        public string? Status { get; set; }
        public string? Excerpt { get; set; }
    }
}
