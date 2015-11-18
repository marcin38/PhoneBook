using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookModel;

namespace PhoneBookLibrary.Services.Interfaces
{
    public interface IService<T>
    {
        BaseResponse Create<S>(S request);
        BaseResponse Delete<S>(S request) where S : EntityCore;
        BaseResponse Edit<S>(S request) where S : EntityCore;
        GetListResponse<S> GetEntriesList<S>(GetListRequest<T> request);
    }

}
