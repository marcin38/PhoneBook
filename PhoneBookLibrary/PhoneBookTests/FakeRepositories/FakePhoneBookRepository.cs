using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookTests.FakeRepositories
{
    public class FakePhoneBookRepository : FakeRepository<PhoneBook>, IPhoneBookRepository
    {
        public List<PhoneBook> phoneBook;

        public FakePhoneBookRepository()
        {
            phoneBook = new List<PhoneBook>();
        }

        public override IEnumerable<PhoneBook> Get(System.Linq.Expressions.Expression<Func<PhoneBook, bool>> filter = null, Func<IQueryable<PhoneBook>, IOrderedQueryable<PhoneBook>> orderBy = null, string includeProperties = "", int rowsNumber = int.MaxValue)
        {
            IQueryable<PhoneBook> query = phoneBook.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).Take(rowsNumber).ToList();
            }
            else
            {
                return query.Take(rowsNumber).ToList();
            }
        }

        public override void Insert(PhoneBook entity)
        {
            phoneBook.Add(entity);
        }

        public override void Delete(PhoneBook entity)
        {
            phoneBook.Remove(entity);
        }

        public override void Update(PhoneBook entity)
        {
            long id = entity.Id;
            phoneBook.RemoveAll(x => x.Id == id);
            phoneBook.Add(entity);
        }
    }
}
