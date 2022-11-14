using ThyreSoft.Photobooth.Core.Models;
using ThyrSoft.Photobooth.Domain.IRepositories;

namespace Thyrsoft.Photobooth.DataAcess.Repositories;

public class UserRepository : IUserRepository
{
    public User Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public User Create(User user)
    {
        throw new NotImplementedException();
    }

    public User GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public User GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}