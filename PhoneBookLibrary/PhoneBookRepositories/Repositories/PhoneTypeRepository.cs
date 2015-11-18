using PhoneBookModel;
using PhoneBookRepositories.Repositories.Interfaces;

namespace PhoneBookRepositories.Repositories
{
    public class PhoneTypeRepository : Repository<PhoneType>, IPhoneTypeRepository
    {
        public PhoneTypeRepository(DatabaseEntities context) : base(context){}
    }
}
