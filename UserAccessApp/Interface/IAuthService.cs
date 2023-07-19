using UserAccessApp.Models;

namespace UserAccessApp.Interface
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
