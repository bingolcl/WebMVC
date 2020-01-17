using Data;

namespace Service
{
    public interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
        User GetAuthenticatedUser();
    }
}
