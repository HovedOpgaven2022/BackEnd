using MySqlConnector;
using ThyreSoft.Photobooth.Core.Models;
using ThyrSoft.Photobooth.Domain.IRepositories;

namespace Thyrsoft.Photobooth.DataAcess.Repositories;

public class PhotoRepository: IPhotoRepository
{
    private const string Table = "Photo";
    private readonly MySqlConnection _connection = new(DbStrings.SqlConnection);
    
    public async Task<Photo> CreatePhoto(Photo photo)
    {
        Photo? p = null;
        await _connection.OpenAsync();

        string uuid = Guid.NewGuid().ToString();
        string sql = $"INSERT INTO {Table} (`id`, `url`) VALUES ('{uuid}', '{photo.Url}');" +
                     $"SELECT * FROM {Table} WHERE `id`='{uuid}'";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync()) p = ReaderToEnt(reader);
        
        await _connection.CloseAsync();
        return p ?? throw new InvalidDataException("Error creating the new photo-entity");
    }

    public async Task<List<Photo>> GetAllPhotos()
    {
        List<Photo> photos = new List<Photo>();

        await _connection.OpenAsync();

        string sql = $"SELECT * FROM {Table}";

        await using var command = new MySqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            photos.Add(ReaderToEnt(reader));
        }
        
        await _connection.CloseAsync();
        
        return photos;
    }

    public Task<List<Photo>> GetPhotosFromDate(string date)
    {
        throw new NotImplementedException();
    }

    private static Photo ReaderToEnt(MySqlDataReader reader)
    {
        return new Photo { Id = reader.GetString(0), Date = reader.GetString(1), Url = reader.GetString(2) };
    }
}