using StockTracking.Account.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace StockTracking.Account.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    }
}
