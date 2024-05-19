using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Autenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
