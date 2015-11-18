using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;

namespace PhoneBookRepositories.Repositories
{
    public class PhoneBookRepository : Repository<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(DatabaseEntities context) : base(context) { }
    }
}
