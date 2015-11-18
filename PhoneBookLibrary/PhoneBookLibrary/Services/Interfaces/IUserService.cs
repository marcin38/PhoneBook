using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookModel;
namespace PhoneBookLibrary.Services.Interfaces
{
    interface IUserService
    {
        BaseResponse Create(CreateUserRequest request);
        BaseResponse Delete(DeleteUserRequest request);
        BaseResponse Edit(EditUserRequest request);
        GetListResponse<UserEntry> GetUserList(GetListRequest<User> request);
        
    }
}
