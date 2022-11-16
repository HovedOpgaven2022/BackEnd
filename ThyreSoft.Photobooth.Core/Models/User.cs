namespace ThyreSoft.Photobooth.Core.Models;

public class User
{
    public User(string? id, string username, string name, string password, string phonenumber)
    {
        this.id = id;
        this.username = username;
        this.name = name;
        this.password = password;
        this.Phone = phonenumber;
    }
    
    public string? id { get; set; }
    public string name { get; set; }
    public string Phone { get; set; }
    public string username { get; set; }
    public string password { get; set; }
}