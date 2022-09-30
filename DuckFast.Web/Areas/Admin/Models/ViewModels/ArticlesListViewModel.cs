using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuckFast.Web.Areas.Admin.Models.ViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<ArticleModel>? Articles { get; set; }
        public SelectList? SelectListCategory { get; set; }
        public SelectList? SelectListAuthor { get; set; }
        public int Category { get; set; }
        public Guid? Author { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public string? Status { get; set; }
    }
}
