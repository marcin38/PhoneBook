using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.AutoMappings;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;

namespace PhoneBookLibrary.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private IService<PhoneBook> phoneBookService;

        public PhoneBookService(IService<PhoneBook> phoneBookService)
        {
            this.phoneBookService = phoneBookService;
            AutoMapperConfig.Register();
        }

        /// <summary>
        /// Creates new PhoneBook
        /// </summary>
        /// <param name="request">Object which defines PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Create(CreatePhoneBookRequest request)
        {
            return phoneBookService.Create(request);
        }

        /// <summary>
        /// Edits existing PhoneBook
        /// </summary>
        /// <param name="request">Object which defines PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Edit(EditPhoneBookRequest request)
        {
            return phoneBookService.Edit<EditPhoneBookRequest>(request);
        }

        /// <summary>
        /// Deletes existing PhoneBook
        /// </summary>
        /// <param name="request">Object which identifies PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Delete(DeletePhoneBookRequest request)
        {
            return phoneBookService.Delete<DeletePhoneBookRequest>(request);
        }

        /// <summary>
        /// Gets list of PhoneBook
        /// </summary>
        /// <param name="request">Defines criteria for selecting items</param>
        /// <returns>List of PhoneBook</returns>
        public GetListResponse<PhoneBookEntry> GetPhoneBookList(GetListRequest<PhoneBook> request)
        {
            return phoneBookService.GetEntriesList<PhoneBookEntry>(request);
        }
    }
}
