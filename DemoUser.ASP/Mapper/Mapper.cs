using DemoUser.ASP.Models;

namespace DemoUser.ASP.Mapper
{
    public static class Mapper
    {
        public static BLL.Entities.User ToBLL(this UserRegisterForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.User(entity.Email, entity.Password);
        }
    }
}
