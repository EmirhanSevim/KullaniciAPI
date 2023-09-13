using KullanicilarAPI.Models;
using KullanicilarAPI.Services.userBookmarkService;
using Microsoft.AspNetCore.Mvc;

namespace KullanicilarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookmarksController : ControllerBase
    {
        private readonly IuserBookmarkService _userBookmarkService;

        public UserBookmarksController(IuserBookmarkService userBookmarkService)
        {
            _userBookmarkService = userBookmarkService;

        }
        [HttpGet]
        public async Task<List<userBookmark>> GetAllUserBookmarks()
        {
            return await _userBookmarkService.GetAllUserBookmarks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<userBookmark>> GetSingleUserBookmark(int id)
        {
            var result = await _userBookmarkService.GetSingleUserBookmark(id);
            if (result is null)
                return NotFound("userBookmark Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<userBookmark>>> AddUserBookmark(userBookmark _userBookmark)
        {
            var result = await _userBookmarkService.AddUserBookmark(_userBookmark);
            if (result is null)
                return NotFound("userBookmark Bulunamadı.");
            return Ok(result);
        }
        [HttpPut]
        public async Task<List<userBookmark>?> GetUserBookmarks(int id, userBookmark request)
        {
            return await _userBookmarkService.UpdateUserBookmark(id, request);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<userBookmark>>> DeleteUserBookmark(int id)
        {
            var result = await _userBookmarkService.DeleteUserBookmark(id);
            if (result is null)
                return NotFound("userBookmark Bulunamadı.");
            return Ok(result);
        }
    }
}
