using User.Application.Models;

namespace User.Application.Helper
{
    public interface JwtAuthentication
    {
        string GenerateToken(UserViewModel username);
    }
}
