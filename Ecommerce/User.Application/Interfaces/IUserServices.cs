
#region Import Packages

using User.Domain.Interfaces;
using User.SharedDTO;

#endregion

namespace User.Application.Interfaces
{
    public interface IUserServices : IUserRepository
    {
        bool AddUser(UserDto userDto);
    }
}
