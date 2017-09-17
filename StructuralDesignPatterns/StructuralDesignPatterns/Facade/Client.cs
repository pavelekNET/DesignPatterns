namespace StructuralDesignPatterns.Facade
{
    public class Client
    {
        public static void Main()
        {
            var auth = new AuthorizationManager();

            //LOGIN
            var userToken = auth.Authorize("mpavelek", "123");

            //LOGOUT
            auth.SignOut(userToken);
        }
    }
}
