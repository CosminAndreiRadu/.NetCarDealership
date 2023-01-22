using ProiectDaw.Data;
using ProiectDaw.Repositories;
using System;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DBcon _context;

        private IUserRepository _user;

        public RepositoryWrapper(DBcon context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if(_user == null ) 
                { 
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
