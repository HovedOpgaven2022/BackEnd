using ThyreSoft.Photobooth.Core.Models;

namespace ThyreSoft.Photobooth.Core.IServices;

public interface IUserService
{
    public User CreateUser(User user);
    public User GetUserByUsername(string username);
    public User GetUserByPhone(string phone);
    public User Login(string username, string password);
    public string GetSalt(string username);
}