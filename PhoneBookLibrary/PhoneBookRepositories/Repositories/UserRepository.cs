using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;

namespace PhoneBookRepositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseEntities context) : base(context){ }
    }
}
