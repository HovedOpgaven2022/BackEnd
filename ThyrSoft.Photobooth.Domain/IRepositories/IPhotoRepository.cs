using ThyreSoft.Photobooth.Core.Models;

namespace ThyrSoft.Photobooth.Domain.IRepositories;

public interface IPhotoRepository
{
    public Task<Photo> CreatePhoto(Photo photo);
    public Task<List<Photo>> GetAllPhotos();
    public Task<List<Photo>> GetPhotosFromDate(string date);
}