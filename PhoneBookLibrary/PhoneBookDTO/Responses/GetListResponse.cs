using System;
using System.Collections.Generic;

namespace PhoneBookDTO.Responses
{
    public class GetListResponse<T> : BaseResponse
    {
        /// <summary>
        /// List containing items
        /// </summary>
        public List<T> Entries { get; set; }

        public GetListResponse()
        {
            Entries = new List<T>();
        }

        public GetListResponse(int status, Exception ex) : base(status, ex) { }
    }


}
