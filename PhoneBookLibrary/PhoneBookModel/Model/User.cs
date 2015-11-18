using System.Collections.Generic;

namespace PhoneBookModel
{
    public partial class User : EntityCore
    {
        public User()
        {
            this.PhoneBooks = new HashSet<PhoneBook>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PhoneBook> PhoneBooks { get; set; }
    }
}
