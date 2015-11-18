using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookModel;
namespace PhoneBookLibrary.Services.Interfaces
{
    interface IPhoneBookService
    {
        BaseResponse Create(CreatePhoneBookRequest request);
        BaseResponse Delete(DeletePhoneBookRequest request);
        BaseResponse Edit(EditPhoneBookRequest request);
        GetListResponse<PhoneBookEntry> GetPhoneBookList(GetListRequest<PhoneBook> request);
    }
}
