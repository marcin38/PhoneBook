using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.AutoMappings;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;

namespace PhoneBookLibrary.Services
{
    public class PhoneTypeService : IPhoneTypeService
    {
        private IService<PhoneType> phoneTypeService;

        public PhoneTypeService(IService<PhoneType> phoneTypeService)
        {
            this.phoneTypeService = phoneTypeService;
            AutoMapperConfig.Register();
        }

        /// <summary>
        /// Creates new PhoneType
        /// </summary>
        /// <param name="request">Object which defines PhoneType</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Create(CreatePhoneTypeRequest request)
        {
            return phoneTypeService.Create(request);
        }

        /// <summary>
        /// Edits existing PhoneType
        /// </summary>
        /// <param name="request">Object which defines PhoneType</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Edit(EditPhoneTypeRequest request)
        {
            return phoneTypeService.Edit<EditPhoneTypeRequest>(request);
        }

        /// <summary>
        /// Deletes existing PhoneType
        /// </summary>
        /// <param name="request">Object which identifies PhoneType</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Delete(DeletePhoneTypeRequest request)
        {
            return phoneTypeService.Delete<DeletePhoneTypeRequest>(request);
        }

        /// <summary>
        /// Gets list of PhoneType
        /// </summary>
        /// <param name="request">Defines criteria for selecting items</param>
        /// <returns>List of PhoneType</returns>
        public GetListResponse<PhoneTypeEntry> GetPhoneTypeList(GetListRequest<PhoneType> request)
        {
            return phoneTypeService.GetEntriesList<PhoneTypeEntry>(request);
        }

    }
}
