using System;
using System.Threading.Tasks;

namespace Backend.Repository
{
  public interface IUserFineboxRepository
  {
    Task Update(string userId, string fineBoxId, bool isAdmin);
    Task JoinFineBox(string userId, string code);
    Task LeaveFineBox(string userId, string fineBoxId);
  }
}
