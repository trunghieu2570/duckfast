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
    public interface IArticleService
    {
        public Task<IEnumerable<Article>> GetArticles();
        public Task<Article?> GetArticle(int id);
        public Task<Article> AddArticle(Article article);
        public Task DeleteArticle(int id);
        public Task<Article> UpdateArticle(Article article);
    }
    public class ArticleService : IArticleService
    {
        private readonly DuckFastDataContext _context;

        public ArticleService(DuckFastDataContext context)
        {
            _context = context;
        }

        public Task<Article> AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article?> GetArticle(int id)
        {
            return await _context.Articles!
                .Include(x => x.Author)
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles!
                .Include(x => x.Author)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            if (!await _context.Articles!.AnyAsync(c => c.Id == article.Id))
                return null!;

            article.UpdatedDate = DateTime.UtcNow;

            _context.Articles!.Update(article);
            await _context.SaveChangesAsync();
            return article;
        }
    }
}
