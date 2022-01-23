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
    public class FineBoxController : ControllerBase
    {
        IFineBoxRepository _fineBoxRepository;

        public FineBoxController(IFineBoxRepository fineBoxRepository)
        {
            _fineBoxRepository = fineBoxRepository;
        }

        [HttpGet("{fineBoxId}")]
        public async Task<FineBox> GetUser(string fineBoxId)
        {
            return await _fineBoxRepository.Get(fineBoxId);

        }

        [HttpPost]
        public async Task Create([FromBody] CreateFineBoxDto createFineBoxDto)
        {
            FineBox fineBox = new();
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
        public async Task EditFineBox(FineBox fineBox)
        {
            await _fineBoxRepository.Update(fineBox); 
        }
       
    }
}
