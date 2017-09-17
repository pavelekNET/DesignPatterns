using System;

namespace StructuralDesignPatterns.Facade.Helpers
{
    public class TokenBasedAuthorization
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
