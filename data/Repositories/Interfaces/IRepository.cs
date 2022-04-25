using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Curate.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        IEnumerable<T> PagedList(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int skip, int count,
            Expression<Func<T, bool>> filter = null, string includeProperties = "");
        IQueryable<T> List(Expression<Func<T, bool>> expression);

        IQueryable<T> All(string includeProperties = "");
        T GetOneByFilter(Expression<Func<T, bool>> filter = null, string includeProperties = "");
    }
}
