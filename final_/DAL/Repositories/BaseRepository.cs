using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Final_project.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_project.DAL.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        readonly DbContext db;
        public BaseRepository(DbContext context)
        {
            db = context;
        }
        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        TEntity IBaseRepository<TEntity>.GetID(Guid id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await db.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

    public void Save()
        {
            
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
