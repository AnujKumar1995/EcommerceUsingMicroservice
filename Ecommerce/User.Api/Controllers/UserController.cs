using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Application.Interfaces;
using User.Application.Models;
using User.SharedDTO;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _repository;
        public UserController(IUserServices repository)
        {
            _repository = repository;
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            bool flag = _repository.AddUser(userDto);
            return Ok(flag);
        }

    }
}
