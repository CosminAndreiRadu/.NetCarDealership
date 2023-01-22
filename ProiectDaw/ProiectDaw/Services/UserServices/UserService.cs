using Microsoft.AspNetCore.Identity;
using ProiectDaw.Models.Constants;
using ProiectDaw.Models.DTOs;
using ProiectDaw.Models.Entities;
using System.Threading.Tasks;

namespace ProiectDaw.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);

                return true;
            }
            return false;

        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            return "";
        }
    }
}
