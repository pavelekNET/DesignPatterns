using System;

namespace StructuralDesignPatterns.Facade
{
    public interface IAuthorization
    {
        Guid Authorize(string userName, string password);
        void SignOut(Guid userToken);
    }
}