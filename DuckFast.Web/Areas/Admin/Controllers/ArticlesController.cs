using Microsoft.AspNetCore.Mvc;

namespace DuckFast.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
