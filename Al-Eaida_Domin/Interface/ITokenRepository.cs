using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(User user);
        Task<string> GenerateRefreshToken();
        Task SaveRefreshTokenAsync(string userId, string refreshToken);
        Task<bool> ValidateRefreshTokenAsync(string userId, string refreshToken);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
