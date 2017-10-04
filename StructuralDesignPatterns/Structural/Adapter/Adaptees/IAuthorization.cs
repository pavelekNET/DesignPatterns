namespace Structural.Adapter.Adaptees
{
    public interface IAuthorization
    {
        bool Login(string userName, string password);
        void Logout();
    }
}