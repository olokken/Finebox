using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Entities;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserFineBoxController : ControllerBase
    {
        IUserFineBoxRepository _userFineBoxRepository;

        public UserFineBoxController(IUserFineBoxRepository userFineBoxRepository)
        {
            _userFineBoxRepository = userFineBoxRepository;
        }

        [HttpPost]
        public async Task JoinFineBox([FromBody] JoinFineBoxDto joinFineBoxDto)
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

