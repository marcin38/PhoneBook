using PhoneBookModel;

namespace PhoneBookDTO.Requests
{
    public class EditPhoneBookRequest : EntityCore
    {
        /// <summary>
        /// Id of user whose number is stored
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Type of phone number
        /// </summary>
        public int PhoneTypeId { get; set; }

        /// <summary>
        /// Telephone number of user
        /// </summary>
        public string Number { get; set; }
    }
}
