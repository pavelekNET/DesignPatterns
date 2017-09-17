using System;

namespace Structural.Facade.Helpers
{
    public class TokenBasedAuthentication
    {
        public Guid GetUserToken(string userName)
        {
            return Guid.NewGuid();
        }

        public string GetUserName(Guid userToken)
        {
            return string.Empty;
        }

        public void DestroyUserToken(Guid userToken)
        {
        }
    }
}
