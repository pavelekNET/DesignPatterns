using StructuralDesignPatterns.Adaptees.Adapter;
using StructuralDesignPatterns.Adapter.Adapters;

namespace StructuralDesignPatterns.Adapter
{
    public class Client
    {
        public static void Main()
        {
            // var auth = new OldAuthorization();
            IAuthorization auth = new TokenBasedAuthorizationAdapter();

            //login
            auth.Login("mpavelek", "123");

            //logout
            auth.Logout();
        }
    }
}
