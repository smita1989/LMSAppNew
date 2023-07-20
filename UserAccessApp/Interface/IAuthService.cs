using UserAccessApp.Models;

namespace UserAccessApp.Interface
{
    public interface IAuthService
    {
        JWTTokenResponse Authenticate(Login user);
    }
}
