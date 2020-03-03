
#region Import Packages

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using User.Application.Helper;
using User.Application.Interfaces;
using User.Application.Models;
using User.SharedDTO;
#endregion


namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region instance
        private readonly IMapper _mapper;
        private readonly IUserServices _repository;
        private readonly JwtAuthentication _jwt;
        #endregion

        #region Constructor
        public LoginController(IUserServices user, JwtAuthentication jwt)
        {
            _repository = user;
            _jwt = jwt;
        
          
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();

        }
        #endregion

        #region SignIn
        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _mapper.Map<UserViewModel>(_repository.UserExists(email));

            if (user != null && user.Password == password)
            {
                var token = _jwt.GenerateToken(user);
            
                return Ok(token);

            }
            else
            {
                return null;
            }

        }
        #endregion

    }
}
