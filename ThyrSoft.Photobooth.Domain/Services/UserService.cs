using ThyreSoft.Photobooth.Core.IServices;
using ThyreSoft.Photobooth.Core.Models;
using ThyrSoft.Photobooth.Domain.IRepositories;

namespace ThyrSoft.Photobooth.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }
    
    public User CreateUser(User user)
    {
        return _repo.Create(user).Result;
    }

    public User GetUserByUsername(string username)
    {
        return _repo.GetUserByUsername(username).Result;
    }

    public User GetUserByName(string username)
    {
        return _repo.GetUserByName(username).Result;
    }

    public User GetUserByPhone(string phone)
    {
        return _repo.GetUserByPhone(phone).Result;
    }
    
    public User Login(string username, string password)
    {
        var accountInfo = _repo.Login(username, password).Result;
        if (accountInfo.username == username && accountInfo.password == password)
        {
            return accountInfo;
        }
        throw new Exception("We did a fuckyWucky");
    }

    public string GetSalt(string username)
    {
        return _repo.GetSalt(username).Result;
    }
}