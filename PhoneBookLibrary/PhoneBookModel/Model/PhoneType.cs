using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookModel
{
    public partial class PhoneType : EntityCore
    {
        public PhoneType()
        {
            this.PhoneBooks = new HashSet<PhoneBook>();
        }

        [MaxLength(20), Column(TypeName = "varchar")]
        public string Name { get; set; }

        public virtual ICollection<PhoneBook> PhoneBooks { get; set; }
    }
}
