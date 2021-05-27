using System;
using System.Collections.Generic;

namespace Projekt.Server.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);

        T Get(Func<T, bool> predicate);

        void Add(T entity);

        void Delete(T entity);
    }
}