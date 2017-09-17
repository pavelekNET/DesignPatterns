using System;
using StructuralDesignPatterns.Facade.Helpers;

namespace StructuralDesignPatterns.Facade
{
    public class AuthorizationManager : IAuthorization
    {
        private readonly ElineWcfClient _elineWcfClient;
        private readonly TokenBasedAuthorization _auth;

        public AuthorizationManager()
        {
            _elineWcfClient = new ElineWcfClient();
            _auth = new TokenBasedAuthorization();
        }

        public Guid Authorize(string userName, string password)
        {
            var userToken = Guid.Empty;

            var authorized = _elineWcfClient.Authorize(userName, password);
            if (authorized)
            {
                userToken = _auth.GetUserToken(userName);
            }

            return userToken;
        }

        public void SignOut(Guid userToken)
        {
            var userName = _auth.GetUserName(userToken);

            _elineWcfClient.Logout(userName);
            _auth.DestroyUserToken(userToken);
        }
    }
}
