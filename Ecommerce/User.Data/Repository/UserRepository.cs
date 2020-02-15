using System;
using User.Data.Context;
using User.Domain.Interfaces;
using User.SharedDTO;

namespace User.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _user;

        public UserRepository(UserDbContext user)
        {
            _user = user;
        }
        public bool AddUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
