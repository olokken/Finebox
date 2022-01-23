using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Backend.Repositories
{
    public class UserFineBoxRepository : IUserFineBoxRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserFineBoxRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task JoinFineBox(string userId, string code)
        {
            var sql = "select f.FineBoxId from fineBox f where f.Code = @code";
            string id = await _dbConnection.QueryFirstOrDefaultAsync<string>(sql, new { code = code });
            var sql2 = "insert into user_finebox values (@fineboxId, @userId, False)";
            await _dbConnection.ExecuteAsync(sql2, new { fineboxId = id, userId = userId });          
        }

        public async Task LeaveFineBox(string userId, string fineBoxId)
        {
            var sql = "delete from user_finebox where userId=@userId and fineboxId=@fineBoxId";
            await _dbConnection.ExecuteAsync(sql, new { userId = userId, fineBoxId = fineBoxId });
        }

        public async Task Update(string userId, string fineBoxId, bool isAdmin)
        {
            var sql = "update user_finebox set IsAdmin=@isAdmin where FineBoxId = @fineBoxId and UserId = @userId";
            await _dbConnection.ExecuteAsync(sql, new { isAdmin = isAdmin, fineBoxId = fineBoxId, userId = userId }); 
        }
    }
}
