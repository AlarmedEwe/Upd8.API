using Upd8.Domain.Entities;

namespace Upd8.Domain.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity? GetById(long id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);

        TEntity AddWithTransaction(TEntity entity);
        TEntity UpdateWithTransaction(TEntity entity);
        TEntity RemoveWithTransaction(TEntity entity);

        TEntity[] GetAll();
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> AddRangeWithTransaction(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> UpdateRangeWithTransaction(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> RemoveRangeWithTransaction(IEnumerable<TEntity> entities);

        void Commit();
        void Rollback();
    }
}
