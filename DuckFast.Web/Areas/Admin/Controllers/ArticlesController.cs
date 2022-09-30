using AutoMapper;
using DuckFast.Common.Services;
using DuckFast.Web.Areas.Admin.Helper;
using DuckFast.Web.Areas.Admin.Models;
using DuckFast.Web.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuckFast.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly IUserAccountService _userAccountService;
        private readonly ICategoryService _categoryService;

        public ArticlesController(
            IMapper mapper,
            IArticleService articleService,
            IUserAccountService userAccountService,
            ICategoryService categoryService)
        {
            _mapper = mapper;
            _articleService = articleService;
            _userAccountService = userAccountService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string search, int category, Guid? author, string status, string sort)
        {
            var articles = await _articleService.GetArticles();
            var users = await _userAccountService.GetUserAccounts();

            if (author.HasValue)
                articles = articles.Where(x => x.Author!.Id == author);
            
            if (!string.IsNullOrEmpty(search))
                articles = articles.Where(x => x.Title!.Contains(search));

            var viewModel = new ArticlesListViewModel
            {
                Articles = _mapper.Map<IEnumerable<ArticleModel>>(articles),
                SelectListAuthor = new SelectList(users.ToSelectList(x => x.DisplayName, x => x.Id), "Value", "Text"),
                SelectListCategory = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Text = "Technology", Value = "1" },
                    new SelectListItem { Text = "Business", Value = "2" },
                    new SelectListItem { Text = "Family", Value = "3" },
                }, "Value", "Text"),
                Search = search,
                Category = category,
                Author = author,
                Status = status,
                Sort = sort
            };

            return View(viewModel!);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var users = await _userAccountService.GetUserAccounts();
            var categories = await _categoryService.GetCategories();
            var article = await _articleService.GetArticle(id);
            var editModel = new ArticleEditViewModel
            {
                SelectListAuthor = new SelectList(users.ToSelectList(x => x.DisplayName, x => x.Id), "Value", "Text"),
                SelectListCategory = new SelectList(categories.ToSelectList(x => x.Name, x => x.Id), "Value", "Text"),
                Author = article!.Author!.Id,
                Category = article!.Category?.Id ?? 0,
                Content = String.Format("<h2>{0}</h2>{1}", article!.Title, article!.Content),
            };
            return View(editModel!);
        }
    }
}
