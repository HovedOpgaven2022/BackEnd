using ThyreSoft.Photobooth.Core.Models;

namespace ThyreSoft.Photobooth.Core.IServices;

public interface IAuthService
{
    
    public string EncodeJwt(User user, byte[] tokenKey);
}