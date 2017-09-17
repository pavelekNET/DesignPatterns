using StructuralDesignPatterns.Adaptees.Adapter;

namespace StructuralDesignPatterns.Adapter.Adaptees
{
    public class OldAuthorization : IAuthorization
    {
        public bool Login(string userName, string password)
        {
            return true;
        }

        public void Logout()
        {
        }
    }
}
