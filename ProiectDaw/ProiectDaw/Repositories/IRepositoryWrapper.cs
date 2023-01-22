using ProiectDaw.Repositories;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
