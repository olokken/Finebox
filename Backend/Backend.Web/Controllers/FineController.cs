using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Repository;
using Backend.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FineController : ControllerBase
  {
    private readonly IFineRepository _fineRepository;

    public FineController(IFineRepository fineRepository)
    {
      _fineRepository = fineRepository;
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<Fine>> GetFines(string id)
    {
      return await _fineRepository.Get(id);
    }

    [HttpPost]
    public async Task<Fine> CreateFine([FromBody] CreateFineDto createFineDto)
    {
      Fine fine = new Fine();
      fine.FineId = Guid.NewGuid().ToString();
      fine.Name = createFineDto.Name;
      fine.FineBoxId = createFineDto.FineBoxId;
      fine.Sum = createFineDto.Sum;
      fine.Description = createFineDto.Description;
      await _fineRepository.Create(fine);
      return fine;
    }

    [HttpPut]
    public async Task EditFine([FromBody] Fine fine)
    {
      await _fineRepository.Edit(fine);
    }
  }
}
