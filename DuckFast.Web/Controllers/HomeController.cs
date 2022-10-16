using AutoMapper;
using DuckFast.Common.Services;
using DuckFast.Web.Models;
using DuckFast.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuckFast.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IArticleService articleService)
        {
            _logger = logger;
            _mapper = mapper;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetArticles();

            var viewModel = new HomeViewModel
            {
                Posts = _mapper.Map<IEnumerable<PostModel>>(articles),
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Post(int pid)
        {
            var article = await _articleService.GetArticle(pid);

            var viewModel = new PostViewModel
            {
                CurrentPost = _mapper.Map<PostModel>(article),
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}