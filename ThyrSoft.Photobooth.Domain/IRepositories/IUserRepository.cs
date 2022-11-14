using ThyreSoft.Photobooth.Core.Models;

namespace ThyrSoft.Photobooth.Domain.IRepositories;

public interface IUserRepository
{
    public Task<User> Login(string username, string password);
    public Task<User> Create(User user);
    
    public Task<User> GetUserByUsername(string username);
    public Task<User> GetUserByEmail(string email);
}