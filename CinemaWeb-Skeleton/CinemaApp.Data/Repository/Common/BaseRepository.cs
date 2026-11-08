using CinemaApp.Data.Repository.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository.Common
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected BaseRepository(ApplicationDbContext context)
        {
            DbContext = context;
            DbSet = context.Set<TEntity>();
        }

        protected ApplicationDbContext DbContext
        {
            get;
        }

        protected DbSet<TEntity> DbSet
        {
            get;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.AddRange(entityCollection);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entityCollection)
        {
            await DbSet.AddRangeAsync(entityCollection);
        }

        public IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> AllAsNoTracking()
        {
            return DbSet
                .AsNoTracking()
                .AsQueryable();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.RemoveRange(entityCollection);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.UpdateRange(entityCollection);
        }
    }
}
