using KullanıcılarAPI.Models;

namespace KullanıcılarAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetSingleCategory(int id);
        Task<List<Category>?> AddCategory(Category categories);
        Task<List<Category>?> UpdateCategory(int id, Category request);
        Task<List<Category>?> DeleteCategory(int id);
    }
}
