
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhoneBookModel
{
    public partial class PhoneBook : EntityCore
    {
        
        public int UserId { get; set; }
        public int PhoneTypeId { get; set; }

        [MaxLength(20), Column(TypeName="varchar")]
        public string Number { get; set; }

        [MaxLength(20), Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [MaxLength(20), Column(TypeName = "varchar")]
        public string LastName { get; set; }

        public virtual PhoneType PhoneType { get; set; }
    }
}
