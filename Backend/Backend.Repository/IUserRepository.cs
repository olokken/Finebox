using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Repository
{
  public interface IUserRepository
  {
    Task Create(User user);
    Task Update(User user);
    Task Delete(string userId);
    Task<User> Get(string userId);
    Task<string> Login(string username, string password);
    Task<IEnumerable<User>> Get();
  }
}
