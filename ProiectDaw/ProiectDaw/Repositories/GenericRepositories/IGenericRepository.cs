using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.GenericRepositories
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);


        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        void Updater(TEntity entity);

        void Delete(TEntity entity);    
        void DeleteRange(IEnumerable<TEntity> entities);


        Task<bool> SaveAsync();
    }
}
