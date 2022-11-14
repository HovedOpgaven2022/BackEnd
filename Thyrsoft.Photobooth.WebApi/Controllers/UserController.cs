using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThyreSoft.Photobooth.Core.Models;
using Thyrsoft.Photobooth.WebApi.DTOs;

namespace Thyrsoft.Photobooth.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult<UserDTO> createUser([FromBody] UserDTO userDto)
        {
            try
            {
                var userInfo = new User(userDto.Id, userDto.AccountName, userDto.Name, userDto.Password);
                
            }
        }
    }
}
