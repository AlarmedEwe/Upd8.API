using Microsoft.EntityFrameworkCore;
using Upd8.Data.Context;
using Upd8.Domain.Core.Interfaces.Repositories;
using Upd8.Domain.Entities;

namespace Upd8.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly Upd8Context db;

        public BaseRepository(Upd8Context context)
        {
            db = context;
        }

        public TEntity Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
            db.SaveChanges();
            return entities;
        }

        public IEnumerable<TEntity> AddRangeWithTransaction(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public TEntity AddWithTransaction(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Commit() => db.SaveChanges();

        public void Dispose() => db.Dispose();

        public TEntity[] GetAll()
            => db.Set<TEntity>().AsNoTracking().ToArray();

        public TEntity? GetById(long id)
            => db.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);

        public TEntity Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            db.SaveChanges();
            return entities;
        }

        public IEnumerable<TEntity> RemoveRangeWithTransaction(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            return entities;
        }

        public TEntity RemoveWithTransaction(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            return entity;
        }

        public void Rollback() => db.Dispose();

        public TEntity Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            db.SaveChanges();
            return entities;
        }

        public IEnumerable<TEntity> UpdateRangeWithTransaction(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public TEntity UpdateWithTransaction(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}