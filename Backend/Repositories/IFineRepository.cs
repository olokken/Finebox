using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Repository
{
    public interface IFineRepository
    {
        Task Create(Fine fine);
        Task Delete(string fineId);
        Task Edit(Fine fine);
        Task<IEnumerable<Fine>> Get(string fineBoxId);
    }
}
