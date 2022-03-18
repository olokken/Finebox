using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Repository
{
  public interface IFineboxRepository
  {
    Task<List<Finebox>> GetByUserId(string userId, IDbConnection dbConnection);
    Task Create(Finebox fineBox);
    Task Delete(string id);
    Task<Finebox> Get(string fineBoxId);
    Task Update(Finebox fineBox);

  }
}