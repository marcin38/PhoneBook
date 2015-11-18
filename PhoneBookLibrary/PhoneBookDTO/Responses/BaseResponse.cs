using System;

namespace PhoneBookDTO.Responses
{
    public class BaseResponse
    {
        public BaseResponse() { }

        public BaseResponse(int status, Exception ex)
        {
            Status = status;
            Message = ex.Message + ex.StackTrace;
        }

        /// <summary>
        /// Status of error if one occured
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Contains error message if one occured
        /// </summary>
        public string Message { get; set; }
    }
}
