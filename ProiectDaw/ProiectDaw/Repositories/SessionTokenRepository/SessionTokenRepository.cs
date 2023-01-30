using Microsoft.EntityFrameworkCore;
using ProiectDaw.Data;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(DBcon context): base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
