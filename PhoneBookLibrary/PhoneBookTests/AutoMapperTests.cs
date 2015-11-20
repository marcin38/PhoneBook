using AutoMapper;
using NUnit.Framework;
using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookLibrary.AutoMappings;
using PhoneBookModel;

namespace PhoneBookTests
{
    public class AutoMapperTests
    {
        [SetUp]
        public void Init()
        {
            AutoMapperConfig.Register();
        }

        [Test]
        public void Register_Mapping_ValidConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Configure_MapPhoneBookToPhoneBookEntry_ValidMapping()
        {
            int id = 1;
            string firstName = "abc";
            string lastName = "efg";
            string number = "123";
            PhoneBook phoneBook = new PhoneBook { Id = id, FirstName = firstName, LastName = lastName, Number = number};

            PhoneBookEntry entry = Mapper.Map<PhoneBook, PhoneBookEntry>(phoneBook);

            Assert.AreEqual(id, entry.Id);
            Assert.AreEqual(firstName, entry.FirstName);
            Assert.AreEqual(lastName, entry.LastName);
            Assert.AreEqual(number, entry.Number);
        }

        [Test]
        public void Configure_MapCreatePhoneBookRequestToPhoneBook_ValidMapping()
        {
            string firstName = "abc";
            string lastName = "efg";
            string number = "123";
            int phoneTypeId = 1;
            CreatePhoneBookRequest request = new CreatePhoneBookRequest { FirstName = firstName, LastName = lastName, Number = number, PhoneTypeId = phoneTypeId };

            PhoneBook phoneBook = Mapper.Map<CreatePhoneBookRequest, PhoneBook>(request);

            Assert.AreEqual(firstName, request.FirstName);
            Assert.AreEqual(lastName, request.LastName);
            Assert.AreEqual(number, request.Number);
            Assert.AreEqual(phoneTypeId, request.PhoneTypeId);
        }

        [Test]
        public void Configure_MapEditPhoneBookRequestToPhoneBook_ValidMapping()
        {
            int id = 1;
            string firstName = "abc";
            string lastName = "efg";
            string number = "123";
            int phoneTypeId = 1;
            EditPhoneBookRequest request = new EditPhoneBookRequest { FirstName = firstName, LastName = lastName, Number = number, PhoneTypeId = phoneTypeId, Id = id };

            PhoneBook phoneBook = Mapper.Map<EditPhoneBookRequest, PhoneBook>(request);

            Assert.AreEqual(id, phoneBook.Id);
            Assert.AreEqual(firstName, request.FirstName);
            Assert.AreEqual(lastName, request.LastName);
            Assert.AreEqual(number, request.Number);
            Assert.AreEqual(phoneTypeId, request.PhoneTypeId);
        }

    }
}
