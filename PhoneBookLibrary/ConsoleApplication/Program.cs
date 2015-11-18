using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.Services;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;
using PhoneBookRepositories.Repositories;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseEntities de = new DatabaseEntities())
            {
                UserRepository ur = new UserRepository(de);
                IService<User> userService = new Service<User>(ur);
                UserService us = new UserService(userService);

                us.Create(new CreateUserRequest { FirstName = "Jan", LastName = "Nowak" });
                us.Create(new CreateUserRequest { FirstName = "Adam", LastName = "Kowalski" });
                us.Create(new CreateUserRequest { FirstName = "Joanna", LastName = "Dąbrowska" });
                us.Edit(new EditUserRequest { FirstName = "Stefan", LastName = "Wiśniewski", Id = 2 });
                us.Delete(new DeleteUserRequest { Id = 1 });
                GetListResponse<UserEntry> r1 = us.GetUserList(new GetListRequest<User> { NumberOfEntries = 10 });
                Console.WriteLine("List of users:");
                foreach (UserEntry entry in r1.Entries)
                {
                    Console.WriteLine("{0} {1}", entry.FirstName, entry.LastName);
                }
                Console.WriteLine();
            }

            using (DatabaseEntities de = new DatabaseEntities())
            {
                PhoneTypeRepository ptr = new PhoneTypeRepository(de);
                IService<PhoneType> phoneTypeService = new Service<PhoneType>(ptr);
                PhoneTypeService pts = new PhoneTypeService(phoneTypeService);

                pts.Create(new CreatePhoneTypeRequest { Name = "Cell" });
                pts.Create(new CreatePhoneTypeRequest { Name = "Work" });
                pts.Create(new CreatePhoneTypeRequest { Name = "Test" });
                pts.Edit(new EditPhoneTypeRequest { Id = 1, Name = "Mobile" });
                pts.Delete(new DeletePhoneTypeRequest { Id = 3 });
                GetListResponse<PhoneTypeEntry> r2 = pts.GetPhoneTypeList(new GetListRequest<PhoneType> { NumberOfEntries = 10 });
                Console.WriteLine("List of phone types:");
                foreach (PhoneTypeEntry entry in r2.Entries)
                {
                    Console.WriteLine(entry.Name);
                }
                Console.WriteLine();
            }

            using (DatabaseEntities de = new DatabaseEntities())
            {
                PhoneBookRepository pbr = new PhoneBookRepository(de);
                IService<PhoneBook> phoneBookService = new Service<PhoneBook>(pbr);
                PhoneBookService pbs = new PhoneBookService(phoneBookService);
                pbs.Create(new CreatePhoneBookRequest { Number = "1234", PhoneTypeId = 1, UserId = 2 });
                pbs.Create(new CreatePhoneBookRequest { Number = "456", PhoneTypeId = 1, UserId = 3 });
                pbs.Create(new CreatePhoneBookRequest { Number = "909", PhoneTypeId = 1, UserId = 2 });
                pbs.Edit(new EditPhoneBookRequest { Id = 2, Number = "587", PhoneTypeId = 2, UserId = 2 });
                pbs.Delete(new DeletePhoneBookRequest { Id = 3 });
            }

            using (DatabaseEntities de = new DatabaseEntities())
            {
                PhoneBookRepository pbr = new PhoneBookRepository(de);
                IService<PhoneBook> phoneBookService = new Service<PhoneBook>(pbr);
                PhoneBookService pbs = new PhoneBookService(phoneBookService);
                
                GetListResponse<PhoneBookEntry> r3 = pbs.GetPhoneBookList(new GetListRequest<PhoneBook> { NumberOfEntries = 10, includeProperties = "" });
                Console.WriteLine("List of phone book entries:");

                foreach (PhoneBookEntry entry in r3.Entries)
                {
                    Console.WriteLine("{0} {1} {2} {3}", new string[] { entry.UserFirstName, entry.UserLastName, entry.Number, entry.PhoneTypeName });
                }
            }

        }
    }
}
