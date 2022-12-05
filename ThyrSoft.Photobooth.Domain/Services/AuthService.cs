using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ThyreSoft.Photobooth.Core.IServices;
using ThyreSoft.Photobooth.Core.Models;

namespace ThyrSoft.Photobooth.Domain.Services;

public class AuthService : IAuthService
{
    public string EncodeJwt(User user, byte[] tokenKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityTokenDescriptor tokenDescriptor;

        tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.NameIdentifier, user.id!, "userId")
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}