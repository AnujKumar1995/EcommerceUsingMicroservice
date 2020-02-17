using User.Domain.Interfaces;
using User.SharedDTO;

namespace User.Application.Interfaces
{
    public interface IUserServices : IUserRepository
    {
        bool AddUser(UserDto userDto);
    }
}
