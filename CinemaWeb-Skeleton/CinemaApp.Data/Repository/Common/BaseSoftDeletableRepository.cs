using CinemaApp.Data.Common.Models;
using CinemaApp.Data.Repository.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository.Common
{
    public abstract class BaseSoftDeletableRepository<TEntity> : BaseRepository<TEntity>, ISoftDeletableRepository<TEntity> where TEntity : class, ISoftDeletableEntity
    {
        protected BaseSoftDeletableRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<TEntity> AllWithDeleted()
        {
            return DbSet
                .IgnoreQueryFilters()
                .AsQueryable();
        }

        public IQueryable<TEntity> AllWithDeletedAsNoTracking()
        {
            return DbSet
                .IgnoreQueryFilters()
                .AsNoTracking()
                .AsQueryable();
        }

        public void Recover(TEntity entity)
        {
            entity.IsDeleted = false;
        }

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
        }
    }
}
