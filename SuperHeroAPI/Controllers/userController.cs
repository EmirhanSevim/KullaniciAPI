using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.KullanıcıService;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IKullanıcıService _superHeroService;

        public userController(IKullanıcıService superHeroService)
        {
           _superHeroService = superHeroService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<bool>> GetUser(string fullname, string password)
        {
            var user = await _superHeroService.GetUser(fullname, password);
            if (user is null)
                return NotFound("User Bulunamadı.");
            return Ok(user);
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllUsers();
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleUser(id);
            if (result is null)
                return NotFound("Kahraman Bulunamadı.");
            return Ok(result);
        }   

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User hero)
        {
            var result = await _superHeroService.AddUser(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateHero(int id, User request) 
        {
            var result = await _superHeroService.UpdateUser(id, request);
            if (result is null)
                return NotFound("Kahraman Bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result =  await _superHeroService.DeleteUser(id);
            if (result is null)
                return NotFound("Kahraman Bulunamadı.");
            return Ok(result);
        }
    }



}
