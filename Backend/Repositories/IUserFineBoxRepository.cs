using System;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IUserFineBoxRepository
    {
        Task Update(string userId, string fineBoxId, bool isAdmin);
        Task JoinFineBox(string userId, string code);
        Task LeaveFineBox(string userId, string fineBoxId); 
    }
}
