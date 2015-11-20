using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;

namespace PhoneBookLibrary.Services.Interfaces
{
    interface IPhoneBookService
    {
        BaseResponse Create(CreatePhoneBookRequest request);
        BaseResponse Delete(DeletePhoneBookRequest request);
        BaseResponse Edit(EditPhoneBookRequest request);
        GetListResponse GetPhoneBookList(GetListRequest request);
    }
}
