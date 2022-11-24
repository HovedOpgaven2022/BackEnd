namespace Thyrsoft.Photobooth.WebApi.DTOs;

public class UserDTO
{
    public string? Id { get; set; }
    public string Name { get; set; }
    
    public string Phone { get; set; }
    public string AccountName { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}