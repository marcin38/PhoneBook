using AutoMapper;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookLibrary.Services
{
    public class Service<T> : IService<T>
        where T : EntityCore
    {
        IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public BaseResponse Create<S>(S r)
        {
            BaseResponse response = new BaseResponse();
            T entity = (T) Mapper.Map(r, r.GetType(), typeof(T));
            
            repository.Insert(entity);
            repository.Save();

            return response;
        }


        public BaseResponse Delete<S>(S request) where S : EntityCore
        {
            BaseResponse response = new BaseResponse();

            try
            {
                List<T> list = repository.Get(x => x.Id == request.Id).ToList();
                if (list.Count == 1)
                {
                    T entity = list.First();
                    repository.Delete(entity);
                    repository.Save();
                }
                else
                {
                    Exception ex = new Exception("Object you are trying to remove does not exist");
                    response = new BaseResponse(1, ex);
                }

            }
            catch (Exception ex)
            {
                response = new BaseResponse(-1, ex);
            }

            return response;
        }

        public BaseResponse Edit<S>(S request) where S : EntityCore
        {
            BaseResponse response = new BaseResponse();

            try
            {
                T entity = repository.Get(x => x.Id == request.Id).ToList().FirstOrDefault();

                if (entity.Id > 0)
                {
                    entity = Mapper.Map<S, T>(request, entity);
                    repository.Update(entity);
                    repository.Save();
                }
                else
                {
                    Exception ex = new Exception("Object you are trying to edit does not exist");
                    response = new BaseResponse(1, ex);
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse(-1, ex);
            }
            return response;
        }

        public GetListResponse<S> GetEntriesList<S>(GetListRequest<T> request)
        {
            GetListResponse<S> response = new GetListResponse<S>();

            try
            {
                List<T> list = repository.Get(request.Filter, request.OrderBy, request.includeProperties ?? "", request.NumberOfEntries).ToList();
                response.Entries = Mapper.Map<List<T>, List<S>>(list);
            }
            catch (Exception ex)
            {
                response = new GetListResponse<S>(-1, ex);
            }
            return response;
        }
    }
}
