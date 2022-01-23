using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Repositories
{
    public interface IFineBoxRepository
    {
        //Task<IEnumerable<FineBox>> GetByUserId(string userId);
        Task Create(FineBox fineBox);
        Task Delete(string id);
        Task<FineBox> Get(string fineBoxId);
        Task Update(FineBox fineBox);      

    }
}