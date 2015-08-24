using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volvox.Reviews.Domain.Models.Common;

namespace Volvox.Reviews.Repository.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> key, int count);
        IEnumerable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> key, int count);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
