using AutoMapper;
using PhoneBookDTO.Entries;
using PhoneBookDTO.Requests;
using PhoneBookDTO.Responses;
using PhoneBookLibrary.AutoMappings;
using PhoneBookLibrary.Services.Interfaces;
using PhoneBookModel;
using PhoneBookRepositories.Repositories;
using PhoneBookRepositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookLibrary.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private IPhoneBookRepository phoneBookRepository;
        private static bool mappingsDone;
        public Func<int> GetUserId;
        
        public PhoneBookService()
        {
            if (!mappingsDone)
            {
                AutoMapperConfig.Register();
                mappingsDone = true;
            }
            phoneBookRepository = new PhoneBookRepository(new DatabaseEntities());
            GetUserId = () => GetId();
        }

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            if (!mappingsDone)
            {
                AutoMapperConfig.Register();
                mappingsDone = true;
            }
            this.phoneBookRepository = phoneBookRepository;
            GetUserId = () => GetId();
        }

        /// <summary>
        /// Creates new PhoneBook
        /// </summary>
        /// <param name="request">Object which defines PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Create(CreatePhoneBookRequest request)
        {
            BaseResponse response = new BaseResponse();
            PhoneBook entity = Mapper.Map<CreatePhoneBookRequest, PhoneBook>(request);
            entity.UserId = GetUserId();

            phoneBookRepository.Insert(entity);
            phoneBookRepository.Save();

            return response;
        }

        /// <summary>
        /// Edits existing PhoneBook
        /// </summary>
        /// <param name="request">Object which defines PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Edit(EditPhoneBookRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                List<PhoneBook> list = phoneBookRepository.Get(x => x.Id == request.Id).ToList();

                if (list.Count() == 1)
                {
                    PhoneBook entity = list.First();
                    if (entity.UserId == GetUserId())
                    {
                        entity = Mapper.Map<EditPhoneBookRequest, PhoneBook>(request, entity);
                        phoneBookRepository.Update(entity);
                        phoneBookRepository.Save();
                    }
                    else
                    {
                        Exception ex = new Exception("You are not authorized to edit this object");
                        response = new BaseResponse(1, ex);
                    }
                }
                else
                {
                    Exception ex = new Exception("Object you are trying to edit does not exist");
                    response = new BaseResponse(2, ex);
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse(-1, ex);
            }
            return response;
        }

        /// <summary>
        /// Deletes existing PhoneBook
        /// </summary>
        /// <param name="request">Object which identifies PhoneBook</param>
        /// <returns>Error message and status if one occured</returns>
        public BaseResponse Delete(DeletePhoneBookRequest request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                List<PhoneBook> list = phoneBookRepository.Get(x => x.Id == request.Id).ToList();
                if (list.Count == 1)
                {
                    PhoneBook entity = list.First();
                    if (entity.UserId == GetUserId())
                    {
                        phoneBookRepository.Delete(entity);
                        phoneBookRepository.Save();
                    }
                    else
                    {
                        Exception ex = new Exception("You are not authorized to delete this object");
                        response = new BaseResponse(1, ex);
                    }
                }
                else
                {
                    Exception ex = new Exception("Object you are trying to remove does not exist");
                    response = new BaseResponse(2, ex);
                }

            }
            catch (Exception ex)
            {
                response = new BaseResponse(-1, ex);
            }

            return response;
        }

        /// <summary>
        /// Gets list of PhoneBook
        /// </summary>
        /// <param name="request">Defines criteria for selecting items</param>
        /// <returns>List of PhoneBook</returns>
        public GetListResponse GetPhoneBookList(GetListRequest request)
        {
            GetListResponse response = new GetListResponse();

            try
            {
                int userId = GetUserId();
                IEnumerable<PhoneBook> list = phoneBookRepository.Get(x => x.UserId == userId);

                Func<PhoneBook, bool> filter = PrepareFiltering(request.FilterByFirstName, request.FilterByLastName);
                if (filter != null)
                    list = list.Where(filter);

                if (request.OrderBy != Order.NoOrdering)
                {
                    Func<IQueryable<PhoneBook>, IOrderedQueryable<PhoneBook>> orderBy = PrepareOrdering(request.OrderBy);
                    list = orderBy(list.AsQueryable());
                }

                response.Entries = Mapper.Map<List<PhoneBook>, List<PhoneBookEntry>>(list.Take(request.NumberOfEntries).ToList());
            }
            catch (Exception ex)
            {
                response = new GetListResponse(-1, ex);
            }
            return response;
        }

        private Func<PhoneBook, bool> PrepareFiltering(string firstName, string lastName)
        {
            Func<PhoneBook, bool> filter = null;

            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName))
            {
                filter = x => x.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase) && x.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                if (!String.IsNullOrEmpty(firstName))
                {
                    filter = x => x.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase);
                }
                if (!String.IsNullOrEmpty(lastName))
                {
                    filter = x => x.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase);
                }
            }
            return filter;
        }

        private Func<IQueryable<PhoneBook>, IOrderedQueryable<PhoneBook>> PrepareOrdering(Order orderBy)
        {
            Func<IQueryable<PhoneBook>, IOrderedQueryable<PhoneBook>> order = null;

            switch(orderBy)
            {
                case Order.OrderByFirstNameAscending:
                    order = x => x.OrderBy(y => y.FirstName);
                    break;
                case Order.OrderByFirstNameDescending:
                    order = x => x.OrderByDescending(y => y.FirstName);
                    break;
                case Order.OrderByLastNameAscending:
                    order = x => x.OrderBy(y => y.LastName);
                    break;
                case Order.OrderByLastNameDescending:
                    order = x => x.OrderByDescending(y => y.LastName);
                    break;
            }

            return order;
        }

        private int GetId()
        {
            // Here should be call to function getting Id of current logged in user
            return 1;
        }
    }
}
