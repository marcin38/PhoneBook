using AutoMapper;
using PhoneBookDTO.Requests;
using PhoneBookModel;
using System;

namespace PhoneBookLibrary.AutoMappings
{
    public class DtoToDomainModelAutoMappings
    {
        public void Configure()
        {
            Mapper.CreateMap<CreatePhoneBookRequest, PhoneBook>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PhoneType, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.UpdateDate, opt => opt.Ignore());

            Mapper.CreateMap<EditPhoneBookRequest, PhoneBook>()
                .ForMember(x => x.PhoneType, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.Ignore())
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(o => DateTime.Now));
        }
    }
}
