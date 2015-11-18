
namespace PhoneBookDTO.Entries
{
    public class PhoneBookEntry
    {
        /// <summary>
        /// Id of element in phone book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Type of phone
        /// </summary>
        public string PhoneTypeName { get; set; }

        /// <summary>
        /// First name of user
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        public string UserLastName { get; set; }
    }
}
