using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.AutoMappings;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;

namespace PhoneBookLibrary.Services
{
    public class UserService : IUserService
    {
        private IService<User> userService;

        public UserService(IService<User> userService)
        {
            this.userService = userService;
            AutoMapperConfig.Register();
        }

        /// <summary>
        /// Creates new User
        /// </summary>
        /// <param name="request">Object which defines User</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Create(CreateUserRequest request)
        {
            return userService.Create(request);
        }

        /// <summary>
        /// Edits existing User
        /// </summary>
        /// <param name="request">Object which defines User</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Edit(EditUserRequest request)
        {
            return userService.Edit<EditUserRequest>(request);
        }

        /// <summary>
        /// Deletes existing User
        /// </summary>
        /// <param name="request">Object which identifies User</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Delete(DeleteUserRequest request)
        {
            return userService.Delete<DeleteUserRequest>(request);
        }

        /// <summary>
        /// Gets list of User
        /// </summary>
        /// <param name="request">Defines criteria for selecting items</param>
        /// <returns>List of User</returns>
        public GetListResponse<UserEntry> GetUserList(GetListRequest<User> request)
        {
            return userService.GetEntriesList<UserEntry>(request);
        }
        
    }
}
