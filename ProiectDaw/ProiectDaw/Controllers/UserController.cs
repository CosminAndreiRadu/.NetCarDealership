using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.Repositories;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }
    }
}
