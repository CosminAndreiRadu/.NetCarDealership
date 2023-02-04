using ProiectDaw.Data;

namespace ProiectDaw.UnitOfWorkf
{
    public interface IUnitOfWork<out TContext> where TContext : DBcon, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();

    }
}
