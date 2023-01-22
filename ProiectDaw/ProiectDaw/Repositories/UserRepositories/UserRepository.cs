using ProiectDaw.Data;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBcon context) : base(context)
        {
        }

        async Task<List<User>> IUserRepository.GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        async Task<User> IUserRepository.GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
