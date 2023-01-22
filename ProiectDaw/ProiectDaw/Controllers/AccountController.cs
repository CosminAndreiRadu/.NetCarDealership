using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.Models.Constants;
using ProiectDaw.Models.DTOs;
using ProiectDaw.Models.Entities;
using ProiectDaw.Services.UserServices;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public AccountController(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already has an account!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if (result)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }


    }
}
