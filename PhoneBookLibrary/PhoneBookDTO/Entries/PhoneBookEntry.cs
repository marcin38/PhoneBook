
namespace PhoneBookDTO.Entries
{
    public class PhoneBookEntry
    {
        /// <summary>
        /// Id of element in phone book
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Telephone number of contact in phone book
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Type of phone number
        /// </summary>
        public string PhoneTypeName { get; set; }

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
