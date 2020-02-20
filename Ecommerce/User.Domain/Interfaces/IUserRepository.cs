using User.SharedDTO;

namespace User.Domain.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(UserDto userDto);
        UserDto UserExists(string email);
    }
}
