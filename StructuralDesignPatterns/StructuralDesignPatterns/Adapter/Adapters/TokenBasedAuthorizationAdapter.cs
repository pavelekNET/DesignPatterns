using System;
using StructuralDesignPatterns.Adaptees.Adapter;
using StructuralDesignPatterns.Adapter.Helpers;

namespace StructuralDesignPatterns.Adapter.Adapters
{
    public class TokenBasedAuthorizationAdapter : IAuthorization
    {
        private readonly TokenBasedAuthentication _auth;
        private readonly IUserContext _userContext;

        public TokenBasedAuthorizationAdapter()
        {
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
