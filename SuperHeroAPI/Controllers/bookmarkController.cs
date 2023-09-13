using KullanıcılarAPI.Models;
using KullanıcılarAPI.Services.BookmarkService;
using Microsoft.AspNetCore.Mvc;

namespace KullanıcılarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {   
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;

        }
        [HttpGet]
        public async Task<List<Bookmark>> GetAllBookmark()
        {
            return await _bookmarkService.GetAllBookmark();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bookmark>> GetSingleBookmark(int id)
        {
            var result = await _bookmarkService.GetSingleBookmark(id);
            if (result is null)
                return NotFound("Bookmark Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Bookmark>>> AddBookmark(Bookmark bookmark)
        {
            var result = await _bookmarkService.AddBookmark(bookmark);
            if (result is null)
                return NotFound("Bookmark Bulunamadı.");
            return Ok(result);
        }

        [HttpPut]
        public async Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request)
        {
            return await _bookmarkService.UpdateBookmark(id, request);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Bookmark>>> DeleteBookmark(int id)
        {
            var result = await _bookmarkService.DeleteBookmark(id);
            if (result is null)
                return NotFound("Bookmark Bulunamadı.");
            return Ok(result);
        }
        [HttpGet("GetBookmarkByCategory")]
        public async Task<ActionResult<Bookmark>> GetBookmarkByCategory(int categoryId)
        {
            var result = await _bookmarkService.GetBookmarkByCategory(categoryId);
            
            return Ok(result);
        }
    }
}
