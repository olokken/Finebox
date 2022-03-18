using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Backend.Repository;
using Backend.Web.Dtos;

namespace Backend.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserFineboxController : ControllerBase
  {
    private readonly IUserFineboxRepository _userFineBoxRepository;

    public UserFineboxController(IUserFineboxRepository userFineBoxRepository)
    {
      _userFineBoxRepository = userFineBoxRepository;
    }

    [HttpPost]
    public async Task JoinFineBox([FromBody] JoinFineboxDto joinFineBoxDto)
    {
      await _userFineBoxRepository.JoinFineBox(joinFineBoxDto.UserId, joinFineBoxDto.Code);
    }

    [HttpPut]
    public async Task MakeAdmin([FromBody] string userId, string fineBoxId)
    {
      await _userFineBoxRepository.Update(userId, fineBoxId, true);
    }

    [HttpDelete]
    public async Task Leave([FromBody] string userId, string fineBoxId)
    {
      await _userFineBoxRepository.LeaveFineBox(userId, fineBoxId);
    }


  }
}

