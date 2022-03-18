using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Web.Dtos;
using Backend.Entities;

using Microsoft.AspNetCore.Mvc;
using Backend.Repository;

namespace Backend.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet("{userId}")]
    public async Task<User> GetUser(string userId)
    {
      return await _userRepository.Get(userId);

    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetUser()
    {
      return await _userRepository.Get();
    }

    [HttpPost]
    public async Task<User> CreateUser([FromBody] CreateUserDto userDto)
    {
      User user = new User();
      user.Name = userDto.Name;
      user.UserId = Guid.NewGuid().ToString();
      user.Password = userDto.Password;
      user.PhoneNumber = userDto.PhoneNumber;
      user.Email = userDto.Email;
      await _userRepository.Create(user);
      return user;
    }

    [HttpPost("Login")]
    public async Task<string> Login([FromBody] LoginDto loginDto)
    {
      string id = await _userRepository.Login(loginDto.Email, loginDto.Password);
      CookieOptions cookieOptions = new();
      Response.Cookies.Append("token", id, cookieOptions);
      return id;
    }

    [HttpPut]
    public async Task EditUser([FromBody] User user)
    {
      await _userRepository.Update(user);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string userId)
    {
      await _userRepository.Delete(userId);
    }
  }
}
