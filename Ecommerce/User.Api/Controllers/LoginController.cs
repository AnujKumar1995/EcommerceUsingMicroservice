using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using User.Api.Helper;
using User.Application.Interfaces;
using User.Application.Models;
using User.SharedDTO;


namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _repository;
       
        public LoginController(IUserServices user)
        {
            _repository = user;
        
          
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _mapper.Map<UserViewModel>(_repository.UserExists(email));

            if (user != null && user.Password == password)
            {
                var token = TokenManager.GenerateToken(user);
            
                return Ok(token);

            }
            else
            {
                return null;
            }

        }

    }
}
