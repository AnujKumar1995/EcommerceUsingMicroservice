
#region Import Packages
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using User.Application.Interfaces;
using User.Application.Models;
using User.SharedDTO;
#endregion

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Instance
        private readonly IMapper _mapper;
        private readonly IUserServices _repository;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public UserController(IUserServices repository, IConfiguration configuration)
        {
            _configuration = configuration;
            _repository = repository;
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region SignUp
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            bool flag = _repository.AddUser(userDto);
            return Ok(flag);
        }
        #endregion

       
    }
}
