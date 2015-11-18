using PhoneBookModel;

namespace PhoneBookDTO.Requests
{
    public class EditPhoneTypeRequest : EntityCore
    {
        /// <summary>
        /// Name of type of phone
        /// </summary>
        public string Name { get; set; }
    }
}
