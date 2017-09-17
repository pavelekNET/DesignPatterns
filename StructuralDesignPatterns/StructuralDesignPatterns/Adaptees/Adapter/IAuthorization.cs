namespace StructuralDesignPatterns.Adaptees.Adapter
{
    public interface IAuthorization
    {
        bool Login(string userName, string password);
        void Logout();
    }
}