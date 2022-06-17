using CRUDApp.Models;

namespace CRUDApp.Services
{
    public class AccountServiceImp : AccountService
    {
        private List<Auth> accounts;

        public AccountServiceImp()
        {
            accounts = new List<Auth> {
                new Auth
                {
                    Username = "admin",
                    Password = "12345",
                    Fullname = "Administrator"
                },
                new Auth
                {
                    Username = "admin1",
                    Password = "12345",
                    Fullname = "Administrator"
                }
            };
        }

        public Auth Login(string username, string password)
        {
            return accounts.SingleOrDefault( a => a.Username == username && a.Password == password);
        }
    }
}