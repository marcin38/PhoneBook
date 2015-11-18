using AutoMapper;
using PhoneBookDTO.Entries;
using PhoneBookModel;

namespace PhoneBookLibrary.AutoMappings
{
    public class DomainModelToDtoAutoMappings
    {
        public void Configure()
        {
            Mapper.CreateMap<PhoneBook, PhoneBookEntry>();
            Mapper.CreateMap<User, UserEntry>();
            Mapper.CreateMap<PhoneType, PhoneTypeEntry>();
        }

    }
}
