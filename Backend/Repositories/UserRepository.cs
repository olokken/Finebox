using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Repository;
using Dapper;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Create(User user)
        {
            var sql = "insert into User values (@UserId, @Name, @PhoneNumber, @Email, @Password)";
            await _dbConnection.ExecuteAsync(sql, user); 
        }

        public async Task Delete(string userId)
        {
            var sql = "delete from user where UserId = @UserId";
            await _dbConnection.ExecuteAsync(sql, new { UserId = userId }); 
        }

        public async Task<User> Get(string userId)
        {
            FineBoxRepository fb = new(_dbConnection); 
            var sql = "select u.UserId, u.Name, u.PhoneNumber, u.Email from User u where u.UserId = @UserId";
            var fineBoxSql = "select fb.FineBoxId from fineBox fb " +
                "join user_finebox uf on fb.fineBoxId = uf.FineboxId " +
                "where uf.UserId = @UserId"; 
            User user =  await _dbConnection.QueryFirstOrDefaultAsync<User>(sql, new { UserId = userId});
            List<string> fineBoxId = (List<string>)await _dbConnection.QueryAsync<string>(fineBoxSql, new { UserId = userId });
            List<FineBox> fineBoxes = new();
            fineBoxId.ForEach(async (x) =>
            {
                fineBoxes.Add(await fb.Get(x)); 
            });
            user.FineBoxes = fineBoxes; 
            return user; 
        }

        public async Task<IEnumerable<User>> Get()
        {
            var sql = "select u.UserId, u.Name, u.PhoneNumber, u.Email from User u";
            return await _dbConnection.QueryAsync<User>(sql); 
        }

        public async Task<string> Login(string email, string password)
        {         
            var sql = "select u.UserId from user u where u.Email = @Email and password = @Password";
            return await _dbConnection.QueryFirstOrDefaultAsync<string>(sql, new { Email = email, Password = password });
        }

        public async Task Update(User user)
        {
            var sql = "update user set Name=@Name, PhoneNumber=@PhoneNumber, Email=@Email, Password=@Password";
            await _dbConnection.ExecuteAsync(sql, new {Name = user.Name, PhoneNumber = user.PhoneNumber, Email = user.Email, Password = user.Password }); 
        }  

    }
}
