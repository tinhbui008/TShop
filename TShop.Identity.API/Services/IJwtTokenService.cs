using TShop.Identity.API.Models;

namespace TShop.Identity.API.Services;

public interface IJwtTokenService
{
    (string Token, DateTime ExpiresAt) GenerateAccessToken(ApplicationUser user, IList<string> roles);
}