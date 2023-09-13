using KullanıcılarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KullanıcılarAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly DataContext _context;
        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>?> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAllCategory();
        }

        public async Task<List<Category>?> DeleteCategory(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null) return null;

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return await GetAllCategory();
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetSingleCategory(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            return categories;
        }

        public async Task<List<Category>?> UpdateCategory(int id, Category request)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null) return null;

            categories.Name = request.Name;
            await _context.SaveChangesAsync();

            return await GetAllCategory();
        }
    }
}
