using Microsoft.AspNetCore.Mvc;
using Thyrsoft.Photobooth.WebApi.DTOs;

namespace Thyrsoft.Photobooth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotoController: ControllerBase
{
    [HttpPost(nameof(UploadPhoto))]
    public ActionResult UploadPhoto([FromBody] PhotoDTO photo)
    {
        return Ok();
    }

    [HttpGet(nameof(GetAllPhotos))]
    public ActionResult<List<PhotoDTO>> GetAllPhotos()
    {
        return Ok();
    }

    [HttpGet(nameof(GetPhotosFromDate) + "/{dateString}")]
    public ActionResult<List<PhotoDTO>> GetPhotosFromDate(string dateString)
    {
        return Ok();
    }
}