using Structural.Adapter.Adaptees;
using Structural.Adapter.Adapters;

namespace Structural.Adapter
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
