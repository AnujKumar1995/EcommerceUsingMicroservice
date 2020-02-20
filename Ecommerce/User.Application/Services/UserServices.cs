using User.Application.Interfaces;
using User.Domain.Interfaces;
using User.SharedDTO;

namespace User.Application.Services
{
    public class UserServices :IUserServices
    {
        private readonly IUserRepository _user;
        public UserServices(IUserRepository services)
        {
            _user = services;
        }

        public bool AddUser(UserDto userDto)
        {
            bool flag = _user.AddUser(userDto);
            return flag;
        }

        public UserDto UserExists(string email)
        {
            var userModel = _user.UserExists(email);
            return userModel;
        }
    }
}
