using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Backend.Entities;
using Dapper;

namespace Backend.Repository
{
    public class FineRepository : IFineRepository
    {
        private readonly IDbConnection _dbConnection;

        public FineRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Create(Fine fine)
        {     
            var sql = "insert into fine values (@FineId, @Name, @Description, @Sum, @FineBoxId)";
            await _dbConnection.ExecuteAsync(sql, fine); 
        }

        public async Task Delete(string fineId)
        {
            var sql = "delete from fine where FineId = @FineId";
            await _dbConnection.ExecuteAsync(sql, new { FineId = fineId });
        }

        public async Task Edit(Fine fine)
        {
            var sql = "update fine set Name=@name, Description=@description, Sum=@sum where FineId=@fineId";
            await _dbConnection.ExecuteAsync(sql, new { name = fine.Name, description = fine.Description, sum = fine.Sum, fineId = fine.FineId }); 
        }

        public async Task<IEnumerable<Fine>> Get(string fineBoxId)
        {
            var sql = "select * from fine where FineBoxId = @fineBoxId";
            return  await _dbConnection.QueryAsync<Fine>(sql, new { fineBoxId = fineBoxId }); 
        }
    }


}

