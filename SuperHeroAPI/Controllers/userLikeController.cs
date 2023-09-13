using KullanicilarAPI.Models;
using KullanicilarAPI.Services.userLikeService;
using Microsoft.AspNetCore.Mvc;

namespace KullanicilarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLikeController : ControllerBase
    {
        private readonly IuserLikeService _userLikeService;

        public UserLikeController(IuserLikeService userLikeService)
        {
            _userLikeService = userLikeService;

        }
        [HttpGet]
        public async Task<List<userLike>> GetAllUserLikes()
        {
            return await _userLikeService.GetAllUserLikes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<userLike>> GetSingleUserLike(int id)
        {
            var result = await _userLikeService.GetSingleUserLike(id);
            if (result is null)
                return NotFound("userLike Bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<userLike>>> AddUserLike(userLike _userLike)
        {
            var result = await _userLikeService.AddUserLike(_userLike);
            if (result is null)
                return NotFound("userLike Bulunamadı.");
            return Ok(result);
        }
        [HttpGet("GetLikeByUser")]
        public async Task<ActionResult<List<userLike>>> GetLikeByUser()
        {
            var result = await _userLikeService.GetLikeByUser();

            return result;
        }
        [HttpPut]
        public async Task<List<userLike>?> GetUserLike(int id, userLike request)
        {
            return await _userLikeService.UpdateUserLike(id, request);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<userLike>>> DeleteUserLike(int id)
        {
            var result = await _userLikeService.DeleteUserLike(id);
            if (result is null)
                return NotFound("userLike Bulunamadı.");
            return Ok(result);
        }
    }
}
