using ThyreSoft.Photobooth.Core.IServices;
using ThyreSoft.Photobooth.Core.Models;
using ThyrSoft.Photobooth.Domain.IRepositories;

namespace ThyrSoft.Photobooth.Domain.Services;

public class PhotoService: IPhotoService
{
    private IPhotoRepository _repo;

    public PhotoService(IPhotoRepository repo)
    {
        _repo = repo;
    }
    public Photo CreatePhoto(Photo photo)
    {
        return _repo.CreatePhoto(photo).Result;
    }

    public List<Photo> GetAllPhotos()
    {
        return _repo.GetAllPhotos().Result;
    }

    public List<Photo> GetPhotosFromDate(string date)
    {
        return _repo.GetPhotosFromDate(date).Result;
    }
}