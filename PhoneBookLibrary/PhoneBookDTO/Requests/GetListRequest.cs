
namespace PhoneBookDTO.Requests
{
    public enum Order
    {
        NoOrdering,
        OrderByFirstNameDescending,
        OrderByFirstNameAscending,
        OrderByLastNameDescending,
        OrderByLastNameAscending,
    }

    public class GetListRequest
    {
        /// <summary>
        /// Number of rows you want to get
        /// </summary>
        public int NumberOfEntries { get; set; }

        /// <summary>
        /// Filter for first name
        /// </summary>
        public string FilterByFirstName { get; set; }

        /// <summary>
        /// Filter for last name
        /// </summary>
        public string FilterByLastName { get; set; }

        /// <summary>
        /// Order of elements
        /// </summary>
        public Order OrderBy { get; set; }
    }
}
