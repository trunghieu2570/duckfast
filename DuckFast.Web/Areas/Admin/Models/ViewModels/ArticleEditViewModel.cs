using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuckFast.Web.Areas.Admin.Models.ViewModels
{
    public class ArticleEditViewModel
    {
        public string? Content { get; set; }
        public SelectList? SelectListCategory { get; set; }
        public SelectList? SelectListAuthor { get; set; }
        public int Category { get; set; }
        public Guid? Author { get; set; }
        public string? Slug { get; set; }
        public string? Excerpt { get; set; }
        public string? Status { get; set; }
    }
}
