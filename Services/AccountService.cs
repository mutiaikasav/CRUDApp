using CRUDApp.Models;

namespace CRUDApp.Services
{
    public interface AccountService
    {
        public Auth Login (string username, string password);
    }
}