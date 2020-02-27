
#region Import Packages
using AutoMapper;
using System.Linq;
using User.Data.Context;
using User.Domain.Interfaces;
using User.Domain.Models;
using User.SharedDTO;
#endregion

namespace User.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Instance
        private readonly UserDbContext _user;
        private readonly IMapper _mapper;
        private bool flag;
        #endregion

        #region constructor
        public UserRepository(UserDbContext user)
        {

            _user = user;

            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, UserModel>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region Add User
        public bool AddUser(UserDto userDto)
        {
            try 
            {
                string email = userDto.Email.ToString();
                flag = false;   
                var isExists = UserExists(email);

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
        #endregion

        #region User Exists or not
        public UserDto UserExists(string email)
        {
            //var userModel = _mapper.Map<UserModel>(user);
            var userExists = _user.UserModels.Where(e => e.Email == email).FirstOrDefault();
            return _mapper.Map<UserDto>(userExists);
        }
        #endregion
    }
}
