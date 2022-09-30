using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuckFast.Web.Areas.Admin.Models.ViewModels
{
    public class CategoriesListViewModel
    {
        public IEnumerable<CategoryModel>? Categories { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public CategoryModel? CurrentCategory { get; set; }
    }
}
