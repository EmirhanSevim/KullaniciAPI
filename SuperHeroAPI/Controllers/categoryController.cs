using KullanicilarAPI.Models;
using KullanicilarAPI.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace KullanicilarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpGet]
        public async Task<List<Category>> GetAllCategory()
        {
             return await _categoryService.GetAllCategory();
           
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetSingleCategory(int id)
        {
            var result = await _categoryService.GetSingleCategory(id);
            if (result is null)
                return NotFound("Category Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            var result = await _categoryService.AddCategory(category);
            if (result is null)
                return NotFound("Category Bulunamadı.");
            return Ok(result);
        }

        [HttpPut]
        public async Task<List<Category>?> UpdateCategory(int id, Category request)
        {
            return await _categoryService.UpdateCategory(id, request);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (result is null)
                return NotFound("Category Bulunamadı.");
            return Ok(result);
        }
    }
}
