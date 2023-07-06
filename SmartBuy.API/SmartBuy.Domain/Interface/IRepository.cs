using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartBuy.Domain
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Delete(T entity);
        void DeleteBulk(IEnumerable<T> entities);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        T Insert(T entity);
        void InsertBulk(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateBulk(IEnumerable<T> entities);
        void CommitChanges();
    }
}