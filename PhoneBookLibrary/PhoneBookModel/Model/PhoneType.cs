using System.Collections.Generic;

namespace PhoneBookModel
{
    public partial class PhoneType : EntityCore
    {
        public PhoneType()
        {
            this.PhoneBooks = new HashSet<PhoneBook>();
        }

        
        public string Name { get; set; }

        public virtual ICollection<PhoneBook> PhoneBooks { get; set; }
    }
}
