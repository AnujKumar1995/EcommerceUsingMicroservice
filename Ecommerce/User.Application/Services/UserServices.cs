
#region Import Packages

using User.Application.Interfaces;
using User.Domain.Interfaces;
using User.SharedDTO;

#endregion

namespace User.Application.Services
{
    public class UserServices :IUserServices
    {

        #region Instance

        private readonly IUserRepository _user;

        #endregion

        #region Constructor
        public UserServices(IUserRepository services)
        {
            _user = services;
        }
        #endregion

        #region Add User
        public bool AddUser(UserDto userDto)
        {
            bool flag = _user.AddUser(userDto);
            return flag;
        }
        #endregion

        #region User Exists or not
        public UserDto UserExists(string email)
        {
            var userModel = _user.UserExists(email);
            return userModel;
        }
        #endregion
    }
}
