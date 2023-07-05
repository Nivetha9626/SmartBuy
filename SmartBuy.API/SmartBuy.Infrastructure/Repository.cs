using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> entities;
        protected DbContext DbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            entities = DbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return entities.Where(filter);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return entities.Add(entity).Entity;
        }

        public void InsertBulk(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            this.entities.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
        }

        public void UpdateBulk(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            this.entities.UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
        }

        public void DeleteBulk(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            this.entities.RemoveRange(entities);
        }

    }
}
