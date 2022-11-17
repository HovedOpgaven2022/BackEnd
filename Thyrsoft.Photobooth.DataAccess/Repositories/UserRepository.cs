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
        return ent ?? throw new InvalidDataException("ERROR: User does not exist");
    }

    public async Task<User> Create(User user)
    {
        User? ent = null;
        string uuid = Guid.NewGuid().ToString();
        await _connection.OpenAsync();

        string sql = $"INSERT INTO {Table} (`uuid`, `name`, `phone`, `username`, `password`)" +
                     $"VALUES ('{uuid}', '{user.name}', '{user.Phone}', '{user.username}', '{user.password}');" +
                     $"SELECT * FROM {Table} WHERE `uuid`='{uuid}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }

    public async Task<User> GetUserByUsername(string username) 
    {
        User? ent = null;
        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table} (`uuid`, `username`, `email`, `password`)" +
                     $"WHERE `username`='{username}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }

    public async Task<User> GetUserByName(string name)
    {
        User? ent = null;
        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table} (`uuid`, `username`, `email`, `password`)" +
                     $"WHERE `name`='{name}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }

    public async Task<User> GetUserByPhone(string phone)
    {   
        User? ent = null;
        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table} (`uuid`, `username`, `email`, `password`)" +
                     $"WHERE `phone`='{phone}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        User? ent = null;
        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table} (`uuid`, `username`, `email`, `password`)" +
                     $"WHERE `email`='{email}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) ent = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return ent ?? throw new InvalidDataException("ERROR: User not created");
    }
    
    private static User ReaderToEnt(MySqlDataReader reader)
    {
        return new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(5));
    }
}