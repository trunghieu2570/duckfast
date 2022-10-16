using AutoMapper;
using DuckFast.Common.Services;
using DuckFast.Database.Entities;
using DuckFast.Web.Areas.Admin.Models.ViewModels;
using DuckFast.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DuckFast.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(
           IMapper mapper,
           ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int selectedCategory, string search, string sort)
        {
            var categories = await _categoryService.GetCategories();

            CategoriesListViewModel viewModel;

            if (selectedCategory != 0)
            {
                var selected = await _categoryService.GetCategory(selectedCategory);

                viewModel = new CategoriesListViewModel
                {
                    Categories = _mapper.Map<IEnumerable<CategoryModel>>(categories),
                    Search = null,
                    Sort = null,
                    CurrentCategory = _mapper.Map<CategoryModel>(selected)
                };
            }
            else
            {
                if (!string.IsNullOrEmpty(search))
                    categories = categories.Where(x => x.Name!.Contains(search));

                viewModel = new CategoriesListViewModel
                {
                    Categories = _mapper.Map<IEnumerable<CategoryModel>>(categories),
                    Search = search,
                    Sort = sort,
                    CurrentCategory = new(),
                };
            }

            return View(viewModel!);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] CategoryModel categoryModel)
        {
            await _categoryService.UpdateCategory(_mapper.Map<Category>(categoryModel));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CategoryModel categoryModel)
        {
            await _categoryService.AddCategory(_mapper.Map<Category>(categoryModel));

            return RedirectToAction("Index");
        }
    }
}
