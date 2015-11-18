
namespace PhoneBookModel
{
    public partial class PhoneBook : EntityCore
    {
        
        public int UserId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }

        public virtual PhoneType PhoneType { get; set; }
        public virtual User User { get; set; }
    }
}
