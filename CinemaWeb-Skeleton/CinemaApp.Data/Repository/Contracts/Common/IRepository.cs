namespace CinemaApp.Data.Repository.Contracts.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllAsNoTracking();

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entityCollection);

        Task AddRangeAsync(IEnumerable<TEntity> entityCollection);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entityCollection);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entityCollection);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
