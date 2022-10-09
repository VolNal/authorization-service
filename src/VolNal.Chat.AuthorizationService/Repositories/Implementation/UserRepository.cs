using Dapper;
using Npgsql;
using VolNal.Chat.AuthorizationService.Infrastructure.Factories.Interfaces;
using VolNal.Chat.AuthorizationService.Repositories.Interfaces;
using VolNal.Chat.AuthorizationService.Repositories.Models;

namespace VolNal.Chat.AuthorizationService.Repositories.Implementation;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;

    public UserRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<UserDto> GetUserAsync(int id)
    {
        var sql = @"SELECT * FROM users WHERE Id = @id";
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<UserDto>(sql, new {id});

        return result.FirstOrDefault();
    }

    public async Task<UserDto> GetUserAsync(string name)
    {
        var sql = @"SELECT * FROM users WHERE Name = @name";

        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<UserDto>(sql, new {name});

        return result.FirstOrDefault();
    }

    public async Task<UserDto> CreateUserAsync(UserDto user)
    {
        var sql = @"INSERT INTO users (Name) VALUES (@Name)
                    returning id, name";
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<UserDto>(sql, new {user.Name});
        
        return result.FirstOrDefault();
    }
}