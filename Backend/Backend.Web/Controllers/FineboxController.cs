using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Web.Dtos;
using Backend.Entities;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FineboxController : ControllerBase
  {
    private readonly IFineboxRepository _fineBoxRepository;

    public FineboxController(IFineboxRepository fineBoxRepository)
    {
      _fineBoxRepository = fineBoxRepository;
    }

    [HttpGet("{fineBoxId}")]
    public async Task<Finebox> GetUser(string fineBoxId)
    {
      return await _fineBoxRepository.Get(fineBoxId);

    }

    [HttpPost]
    public async Task Create([FromBody] CreateFineBoxDto createFineBoxDto)
    {
      Finebox fineBox = new();
      User user = new();
      user.UserId = createFineBoxDto.UserId;
      fineBox.Admins.Add(user);
      fineBox.FineBoxId = Guid.NewGuid().ToString();
      fineBox.Name = createFineBoxDto.Name;
      fineBox.PaymentDescription = createFineBoxDto.PaymentDescription;
      await _fineBoxRepository.Create(fineBox);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string fineBoxId)
    {
      await _fineBoxRepository.Delete(fineBoxId);
    }


    [HttpPut]
    public async Task EditFineBox(Finebox fineBox)
    {
      await _fineBoxRepository.Update(fineBox);
    }

  }
}
