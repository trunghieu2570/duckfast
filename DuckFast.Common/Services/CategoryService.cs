using DuckFast.Database;
using DuckFast.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckFast.Common.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category?> GetCategory(int id);
        public Task<Category> AddCategory(Category Category);
        public Task DeleteCategory(int id);
        public Task<Category> UpdateCategory(Category Category);
    }
    public class CategoryService : ICategoryService
    {
        private readonly DuckFastDataContext _context;

        public CategoryService(DuckFastDataContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _context.Categories!.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories!.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories!.ToListAsync();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            if (!await _context.Categories!.AnyAsync(c => c.Id == category.Id)) 
                return null!;

            _context.Categories!.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
