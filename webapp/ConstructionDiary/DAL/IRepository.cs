using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConstructionDiary.DAL
{
    public interface IRepository<T> where T:class
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        IEnumerable<T> List(ISpecification<T> spec);
        T GetSingle(ISpecification<T> spec);
    }
}
