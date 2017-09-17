using System;

namespace StructuralDesignPatterns.Adapter.Helpers
{
    public class TokenBasedAuthentication
    {
        public Guid SignIn(string userName, string password)
        {
            return Guid.NewGuid();
        }

        public Guid GetUserToken(string userName)
        {
            return Guid.NewGuid()`
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
