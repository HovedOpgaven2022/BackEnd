using System.Threading.Tasks;
using ThyreSoft.Photobooth.Core.Models;

namespace ThyrSoft.Photobooth.Domain.IRepositories;

public interface IUserRepository
{
    public Task<User> Login(string username, string password);
    public Task<User> Create(User user);
    
    public Task<User> GetUserByUsername(string username);
    public Task<User> GetUserByName(string name);

    public Task<User> GetUserByPhone(string email);
    public Task<string> GetSalt(string username);
}