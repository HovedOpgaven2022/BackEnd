using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThyreSoft.Photobooth.Core.IServices;
using ThyreSoft.Photobooth.Core.Models;
using Thyrsoft.Photobooth.WebApi.DTOs;

namespace Thyrsoft.Photobooth.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserDTO> TestMethod()
        {
            return Ok(new UserDTO());
        }

        [HttpPost(nameof(CreateUser))]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDto)
        {
            try
            {
                var userInfo = new User(userDto.Id, userDto.AccountName, userDto.Name, userDto.Password, userDto.Phone, userDto.Salt);

                var accountCreated = _userService.CreateUser(userInfo);
                return Created($"https://localhost/api/User/{accountCreated.id}", accountCreated);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost(nameof(Login))]
        public ActionResult<LoginDTO> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                return Ok(_userService.Login(loginDto.AccountName, loginDto.Password));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost(nameof(GetSalt) + "/{username}")]
        public ActionResult<string> GetSalt(string username)
        {
            try
            {
                string salt = _userService.GetSalt(username);
                if (salt == null || salt == "") return Ok("");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(nameof(GetUserByUsername))]
        public ActionResult<UserDTO> GetUserByUsername(string username)
        {
            try
            {
                return Ok(_userService.GetUserByUsername(username));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet(nameof(GetUserByPhone))]
        public ActionResult<UserDTO> GetUserByPhone(string phone)
        {
            try
            {
                return Ok(_userService.GetUserByPhone(phone));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
