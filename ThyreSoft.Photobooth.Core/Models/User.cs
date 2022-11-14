namespace ThyreSoft.Photobooth.Core.Models;

public class User
{
    public User(string? id, string username, string email, string password)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.password = password;
    }
    
    public string? id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}