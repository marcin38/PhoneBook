using System.Data.Entity;

namespace PhoneBookModel
{
    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }

        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
