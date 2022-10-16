using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuckFast.Web.Areas.Admin.Models.ViewModels
{
    public class ArticleEditViewModel : ArticleRequestModel
    {
        public string? PrevContent { get; set; }
        public SelectList? SelectListCategory { get; set; }
        public SelectList? SelectListAuthor { get; set; }
    }
}
