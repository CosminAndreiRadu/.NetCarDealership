using Microsoft.EntityFrameworkCore.Internal;
using ProiectDaw.Models.DTOs;
using System.Threading.Tasks;

namespace ProiectDaw.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
