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
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.UpdateDate, opt => opt.Ignore());

            Mapper.CreateMap<CreatePhoneTypeRequest, PhoneType>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PhoneBooks, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.UpdateDate, opt => opt.Ignore());

            Mapper.CreateMap<CreateUserRequest, User>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PhoneBooks, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.MapFrom(o => DateTime.Now))
                .ForMember(x => x.UpdateDate, opt => opt.Ignore());

            Mapper.CreateMap<EditPhoneBookRequest, PhoneBook>()
                .ForMember(x => x.PhoneType, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.Ignore())
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(o => DateTime.Now));

            Mapper.CreateMap<EditPhoneTypeRequest, PhoneType>()
                .ForMember(x => x.PhoneBooks, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.Ignore())
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(o => DateTime.Now));

            Mapper.CreateMap<EditUserRequest, User>()
                .ForMember(x => x.PhoneBooks, opt => opt.Ignore())
                .ForMember(x => x.InsertDate, opt => opt.Ignore())
                .ForMember(x => x.UpdateDate, opt => opt.MapFrom(o => DateTime.Now));

        }
    }
}
