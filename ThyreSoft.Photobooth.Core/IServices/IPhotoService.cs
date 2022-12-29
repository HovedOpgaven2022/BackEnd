using ThyreSoft.Photobooth.Core.Models;

namespace ThyreSoft.Photobooth.Core.IServices;

public interface IPhotoService
{
    public Photo CreatePhoto(Photo photo);
    public List<Photo> GetAllPhotos();
    public List<Photo> GetPhotosFromDate(string date);
}