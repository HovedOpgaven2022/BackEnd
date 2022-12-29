using Microsoft.AspNetCore.Mvc;
using ThyreSoft.Photobooth.Core.IServices;
using ThyreSoft.Photobooth.Core.Models;
using Thyrsoft.Photobooth.WebApi.DTOs;

namespace Thyrsoft.Photobooth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotoController: ControllerBase
{
    private IPhotoService _service;
    
    public PhotoController(IPhotoService service)
    {
        _service = service;
    }
    
    [HttpPost(nameof(UploadPhoto))]
    public ActionResult<Photo> UploadPhoto([FromBody] PhotoDTO photo)
    {
        var _photo = new Photo { Id = null, Url = photo.url, Date = photo.date };
        var res = _service.CreatePhoto(_photo);
        return Ok(res);
    }

    [HttpGet(nameof(GetAllPhotos))]
    public ActionResult<List<PhotoDTO>> GetAllPhotos()
    {
        return Ok(_service.GetAllPhotos());
    }

    [HttpGet(nameof(GetPhotosFromDate) + "/{dateString}")]
    public ActionResult<List<PhotoDTO>> GetPhotosFromDate(string dateString)
    {
        return Ok(_service.GetPhotosFromDate(dateString));
    }
}