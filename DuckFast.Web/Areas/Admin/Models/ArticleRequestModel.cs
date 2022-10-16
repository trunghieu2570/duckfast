namespace DuckFast.Web.Areas.Admin.Models
{
    public class ArticleRequestModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int Category { get; set; }
        public string? Author { get; set; }
        public string? Slug { get; set; }
        public string? Excerpt { get; set; }
        public string? Status { get; set; }
    }
}
