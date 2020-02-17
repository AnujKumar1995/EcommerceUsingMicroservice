using AutoMapper;
using System;
using System.Linq;
using User.Data.Context;
using User.Domain.Interfaces;
using User.Domain.Models;
using User.SharedDTO;

namespace User.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _user;
        private readonly IMapper _mapper;
        private bool flag;

        public UserRepository(UserDbContext user)
        {

            _user = user;

            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, UserModel>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        public bool AddUser(UserDto userDto)
        {
            try 
            {
                flag = false;   
                var isExists = UserExists(userDto);

                if (isExists == null)
                {
                    var userModel = _mapper.Map<UserModel>(userDto);
                    userModel.Role = "Customer";
                    _user.Add(userModel);
                    _user.SaveChanges();
                    flag = true;
                    return flag;
                }
                else {
                    flag = false;
                    return flag;
                }
            }
            catch
            {
                return false;
            }
           
        }

        public UserDto UserExists(UserDto user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var userExists = _user.UserModels.Where(e => e.Email == userModel.Email).FirstOrDefault();
            return _mapper.Map<UserDto>(userExists);
        }
    }
}
