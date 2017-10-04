using System;
using Structural.Adapter.Adaptees;
using Structural.Adapter.Helpers;

namespace Structural.Adapter.Adapters
{
    public class TokenBasedAuthorizationAdapter : IAuthorization
    {
        private readonly TokenBasedAuthentication _auth;
        private readonly IUserContext _userContext;

        public TokenBasedAuthorizationAdapter()
        {
            _userContext = (IUserContext)new object();
            _auth = new TokenBasedAuthentication();
        }

        public bool Login(string userName, string password)
        {
            var token = _auth.SignIn(userName, password);
            return token != Guid.Empty;
        }

        public void Logout()
        {
            var currentUserName = _userContext.GetCurrentUserName();
            var userToken = _auth.GetUserToken(currentUserName);
            _auth.DestroyUserToken(userToken);
        }
    }
}
