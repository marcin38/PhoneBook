using NUnit.Framework;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary;
using PhoneBookLibrary.Services;
using PhoneBookModel;
using PhoneBookTests.FakeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookTests
{
    public class PhoneBookServiceTests
    {
        [Test]
        public void Create_SimpleValues_AddedToPhoneBook()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };

            service.Create(new CreatePhoneBookRequest { FirstName = "Adam", LastName = "Kowalski", Number = "123456", PhoneTypeId = 1});

            Assert.AreEqual(1, repository.phoneBook.Count());
            Assert.AreEqual("Adam", repository.phoneBook.First().FirstName);
            Assert.AreEqual("Kowalski", repository.phoneBook.First().LastName);
            Assert.AreEqual("123456", repository.phoneBook.First().Number);
            Assert.AreEqual(1, repository.phoneBook.First().PhoneTypeId);
            Assert.AreEqual(service.GetUserId(), repository.phoneBook.First().UserId);
        }

        [Test]
        public void Delete_NonExistingEntryInPhoneBook_ResponseStatusSetTo2()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };

            BaseResponse response = service.Delete(new DeletePhoneBookRequest { Id = 1 });

            Assert.AreEqual(2, response.Status);
        }

        [Test]
        public void Delete_ExistingEntryInPhoneBookBelongingToDifferentUser_ResponseStatusSetTo1()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };
            repository.phoneBook.Add(new PhoneBook { UserId = service.GetUserId() + 1, Id = 1 });

            BaseResponse response = service.Delete(new DeletePhoneBookRequest { Id = 1 });

            Assert.AreEqual(1, response.Status);
        }


        [Test]
        public void Delete_ExistingEntry_RemovedFromPhoneBook()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };

            repository.phoneBook.Add(new PhoneBook { Id = 1, UserId = service.GetUserId() });
            BaseResponse response = service.Delete(new DeletePhoneBookRequest { Id = 1 });

            Assert.AreEqual(0, repository.phoneBook.Count());
        }

        [Test]
        public void Edit_NonExistingEntryInPhoneBook_ResponseStatusSetTo2()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };

            BaseResponse response = service.Edit(new EditPhoneBookRequest { Id = 1 });

            Assert.AreEqual(2, response.Status);
        }

        [Test]
        public void Edit_ExistingEntryInPhoneBookBelongingToDifferentUser_ResponseStatusSetTo1()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 };
            repository.phoneBook.Add(new PhoneBook { UserId = service.GetUserId() + 1, Id = 1 });

            BaseResponse response = service.Edit(new EditPhoneBookRequest { Id = 1 });

            Assert.AreEqual(1, response.Status);
        }


        [Test]
        public void Edit_ExistingEntry_UpdatedInPhoneBook()
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => 1 }; 

            repository.phoneBook.Add(new PhoneBook { Id = 1, UserId = service.GetUserId() });
            BaseResponse response = service.Edit(new EditPhoneBookRequest { Id = 1, FirstName = "First", LastName="Last", Number="123456", PhoneTypeId=2 });

            Assert.AreEqual(1, repository.phoneBook.First().Id);
            Assert.AreEqual("First", repository.phoneBook.First().FirstName);
            Assert.AreEqual("123456", repository.phoneBook.First().Number);
            Assert.AreEqual(2, repository.phoneBook.First().PhoneTypeId);
        }

        private static readonly Order[] enumValues = (Order[])Enum.GetValues(typeof(Order));

        [Test]
        public void GetPhoneBookList_SpecifiedOptions_ListOfContactsForGivenUserId(
            [Values(1, 2, 3)] int userId,
            [Values(1,5,10)] int numberOfEntries,
            [Values("adam", "")] string firstNameFilter,
            [Values("ast", "")] string lastNameFilter,
            [ValueSource("enumValues")] Order orderBy)
        {
            FakePhoneBookRepository repository = new FakePhoneBookRepository();
            PhoneBookService service = new PhoneBookService(repository) { GetUserId = () => userId };
            int count = 10;
            GeneratePhoneBook(count, repository);

            GetListResponse response = service.GetPhoneBookList(new GetListRequest
            {
                NumberOfEntries = numberOfEntries,
                FilterByFirstName = firstNameFilter,
                FilterByLastName = lastNameFilter,
                OrderBy = orderBy,                
            });
            IEnumerable<PhoneBook> list = repository.phoneBook.Where(x => x.UserId == userId && x.FirstName.Contains(firstNameFilter, StringComparison.OrdinalIgnoreCase) && x.LastName.Contains(lastNameFilter, StringComparison.OrdinalIgnoreCase)).ToList();

            switch (orderBy)
            {
                case Order.OrderByFirstNameAscending:
                    list = list.OrderBy(y => y.FirstName);
                    break;
                case Order.OrderByFirstNameDescending:
                    list = list.OrderByDescending(y => y.FirstName);
                    break;
                case Order.OrderByLastNameAscending:
                    list = list.OrderBy(y => y.LastName);
                    break;
                case Order.OrderByLastNameDescending:
                    list = list.OrderByDescending(y => y.LastName);
                    break;
            }

            list = list.Take(numberOfEntries);

            Assert.AreEqual(list.Count(), response.Entries.Count());
            int listCount = list.Count();
            for(int i = 0; i < listCount; i++)
            {
                Assert.AreEqual(list.ElementAt(i).Id, response.Entries.ElementAt(i).Id);
            }

        }

        private void GeneratePhoneBook(int count, FakePhoneBookRepository repository)
        {
            repository.phoneBook.Add(new PhoneBook
            {
                FirstName = "Adam",
                LastName = "Kowalski",
                Id = 10,
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
            });

            repository.phoneBook.Add(new PhoneBook
            {
                FirstName = "Bartosz",
                LastName = "Z",
                Id = 11,
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
            });


            repository.phoneBook.Add(new PhoneBook
            {
                FirstName = "Zenon",
                LastName = "X",
                Id = 12,
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
            });

            for(int i = 0; i < count - 3; i++)
            {
                repository.phoneBook.Add(new PhoneBook
                {
                    FirstName = "First" + i.ToString(),
                    LastName =  "Last" + i.ToString(),
                    Id = i + 1,
                    Number = i.ToString(),
                    PhoneTypeId = (i % 3) + 1,
                    UserId = 1 + i/5
                });
            }


        }
    }
}
