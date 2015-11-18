using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBookRepositories.Repositories
{
        public class Repository<T> : IRepository<T> where T : class
        {
            protected DatabaseEntities context;

            public Repository(DatabaseEntities context)
            {
                this.context = context;
            }

            public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "", int rowsNumber = int.MaxValue)
            {
                IQueryable<T> query = context.Set<T>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).Take(rowsNumber);
                }
                else
                {
                    return query.Take(rowsNumber);
                }
            }

            public void Insert(T entity)
            {
                context.Set<T>().Add(entity);
            }

            public void Delete(T entity)
            {
                context.Set<T>().Remove(entity);
            }

            public void Update(T entity)
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }

            public void Save()
            {
                context.SaveChanges();
            }
        }
}
