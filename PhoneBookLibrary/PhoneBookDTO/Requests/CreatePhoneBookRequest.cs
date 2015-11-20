
namespace PhoneBookDTO.Requests
{
    public class CreatePhoneBookRequest
    {
        /// <summary>
        /// Type of phone number
        /// </summary>
        public int PhoneTypeId { get; set; }

        /// <summary>
        /// Telephone number of contact in phone book
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// First name of contact in phone book
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of contact in phone book
        /// </summary>
        public string LastName { get; set; }
    }
}
