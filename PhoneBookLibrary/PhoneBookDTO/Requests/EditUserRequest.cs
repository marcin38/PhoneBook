using PhoneBookModel;

namespace PhoneBookDTO.Requests
{
    public class EditUserRequest : EntityCore
    {
        /// <summary>
        /// First name of user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        public string LastName { get; set; }
    }
}
