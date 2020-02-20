using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _configuration;
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

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            bool flag = _repository.AddUser(userDto);
            return Ok(flag);
        }

        //[HttpPost, Route("/login")]
        //public IActionResult Login(string Email, string Password)
        //{
        //    //var userDtoModel = _mapper.Map<UserDto>(viewModel);
        //    var user = _mapper.Map<UserViewModel>(_repository.UserExists(Email));
        //    if (user != null && user.Password == Password)
        //    {
        //        var claim = new[] { new Claim(JwtRegisteredClaimNames.Sub, user.Role) };
                

        //        var signinKey = new SymmetricSecurityKey
        //          (
        //            Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"])
        //          );

        //        int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);
        //        var token = new JwtSecurityToken(
        //            claims:claim,
        //            issuer: _configuration["Jwt:Site"],
        //            audience: _configuration["Jwt:Site"],
        //            expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
        //            signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
        //            );
        //        return Ok(
        //            new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token),
        //                expiration = token.ValidTo
        //            }
        //            );
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }

        //}
    }
}
