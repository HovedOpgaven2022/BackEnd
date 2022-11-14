using ThyreSoft.Photobooth.Core.Models;

namespace ThyrSoft.Photobooth.Domain.IRepositories;

public interface IUserRepository
{
    public User Login(string username, string password);
    public User Create(User user);
    
    public User GetUserByUsername(string username);
    public User GetUserByEmail(string email);
}