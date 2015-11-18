using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookModel;
namespace PhoneBookLibrary.Services.Interfaces
{
    interface IPhoneTypeService
    {
        BaseResponse Create(CreatePhoneTypeRequest request);
        BaseResponse Delete(DeletePhoneTypeRequest request);
        BaseResponse Edit(EditPhoneTypeRequest request);
        GetListResponse<PhoneTypeEntry> GetPhoneTypeList(GetListRequest<PhoneType> request);
    }
}
