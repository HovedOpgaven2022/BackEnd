using System;
using System.IO;
using System.Threading.Tasks;
using MySqlConnector;
using ThyreSoft.Photobooth.Core.Models;
using ThyrSoft.Photobooth.Domain.IRepositories;

namespace Thyrsoft.Photobooth.DataAcess.Repositories;

public class UserRepository : IUserRepository
{
    private const string Table = "User";
    private readonly MySqlConnection _connection = new(DbStrings.SqlConnection);
    
    public async Task<User> Login(string username, string password)
    {
        User? ent = null;
        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table} WHERE `username`='{username}' AND `password`='{password}';";
        
        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);

        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }

    public async Task<User> Create(User user)
    {
        User? ent = null;
        string uuid = Guid.NewGuid().ToString();
        await _connection.OpenAsync();

        string sql = $"INSERT INTO {Table} (`uuid`, `username`, `email`, `password`)" +
                     $" VALUES ('{uuid}', '{user.username}', '{user.name}', '{user.password}');";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }

    public Task<User> GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmail(string email)
    {   
        throw new NotImplementedException();
    }
    
    private static User ReaderToEnt(MySqlDataReader reader)
    {
        return new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
    }
}