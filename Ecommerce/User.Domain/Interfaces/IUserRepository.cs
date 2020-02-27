
#region Import Packages

using User.SharedDTO;

#endregion

namespace User.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Interfaces
        bool AddUser(UserDto userDto);
        UserDto UserExists(string email);
        #endregion
    }
}
