
namespace PhoneBookLibrary.AutoMappings
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            new DtoToDomainModelAutoMappings().Configure();
            new DomainModelToDtoAutoMappings().Configure();
        }
    }
}
