using PhoneBookDTO.Entries;
using System;
using System.Collections.Generic;

namespace PhoneBookDTO.Responses
{
    public class GetListResponse : BaseResponse
    {
        /// <summary>
        /// List containing items
        /// </summary>
        public List<PhoneBookEntry> Entries { get; set; }

        public GetListResponse()
        {
            Entries = new List<PhoneBookEntry>();
        }

        public GetListResponse(int status, Exception ex) : base(status, ex) { }
    }


}
