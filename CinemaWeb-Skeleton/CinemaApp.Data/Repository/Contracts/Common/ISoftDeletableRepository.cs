using CinemaApp.Data.Common.Models;

namespace CinemaApp.Data.Repository.Contracts.Common
{
    public interface ISoftDeletableRepository<TEntity> : IRepository<TEntity> where TEntity : class, ISoftDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllWithDeletedAsNoTracking();

        void SoftDelete(TEntity entity);

        void Recover(TEntity entity);
    }
}
