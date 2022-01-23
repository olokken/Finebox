﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Repositories;
using Dapper;

namespace Backend.Repository
{
    public class FineBoxRepository : IFineBoxRepository
    {

        private readonly IDbConnection _dbConnection;

        public FineBoxRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        

        public static string RandomString(int length)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task Create(FineBox fineBox)
        {
            var sql = "insert into fineBox values (@FineBoxId, @Name, @Code, @PaymentDescription)";
            var sql2 = "insert into user_finebox values (default, @fineboxId, @userId, @isAdmin)"; 
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                string id = Guid.NewGuid().ToString();

                await _dbConnection.ExecuteAsync(sql,
                    new { FineBoxId = id, Name = fineBox.Name, Code = RandomString(6), PaymentDescription = fineBox.PaymentDescription }, transaction: transaction);

                await _dbConnection.ExecuteAsync(sql2,
                    new { fineboxId = id, userId = fineBox.Admins[0].UserId, isAdmin = true }, transaction: transaction);

                transaction.Commit();
            }
        }

        public async Task Delete(string id)
        {
            var sql = "delete from fine_box where fineBoxId = @id";
            await _dbConnection.ExecuteAsync(sql, new { id = id });
        }

        public async Task<FineBox> Get(string fineBoxId)
        {
            var participantsSql = "select  from user u join user_finebox uf on u.userId = uf.userId where uf.fineboxId = @Id and uf.isAdmin = False;";
            var adminsSql = "select * from user u join user_finebox uf on u.userId = uf.userId where uf.fineboxId = @Id and uf.isAdmin = True";
            var finesSql = "select * from fine where fineBoxId = @Id";
            var sql = "select * from fineBox fb where fb.fineBoxId = @fineBoxId";
            var participants = await _dbConnection.QueryAsync<User>(participantsSql, new { Id = fineBoxId });
            var admins = await _dbConnection.QueryAsync<User>(adminsSql, new { Id = fineBoxId });
            var fines = await _dbConnection.QueryAsync<Fine>(finesSql, new { id = fineBoxId });
            var info = await _dbConnection.QueryFirstOrDefaultAsync<FineBox>(sql, new { fineBoxId = fineBoxId }); 
            FineBox fineBox = new FineBox(info.FineBoxId, info.Name, info.Code, info.PaymentDescription,
                (List<User>)admins, (List<User>)participants, (List<Fine>)fines); 
            return fineBox;
        }

        public async Task Update(FineBox fineBox)
        {
            var sql = "update fine_box set name=@name, code=@code, paymentDescription=@paymentDescription " +
                "where fineBoxId = @fineBoxId";
            await _dbConnection.ExecuteAsync(sql, fineBox);

        }

       
        

  

       
    }
}
