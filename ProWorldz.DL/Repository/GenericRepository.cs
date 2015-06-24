using ProWorldz.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext Context;
        private DbSet<TEntity> DbSet;
        private bool _dispose;
        public GenericRepository(DbContext _context)
        {
            Context = _context;
            DbSet = Context.Set<TEntity>();

        }

        public TEntity GetByID(int id)
        {
            return DbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public List<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression = null)
        {
            return DbSet.AsNoTracking().Where(expression).ToList();
        }

        public void Add(TEntity entity)
       {
            //Context.Entry(entity).State = EntityState.Added;
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            
            Context.Entry(entity).State = EntityState.Modified;
            //Context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = GetByID(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                _dispose = true;
            }
        }
    }
}
