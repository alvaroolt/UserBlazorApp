using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public interface IServiceAccount
    {
        Task<IEnumerable<Account>> DameAccounts();
        Task<IEnumerable<Account>> DameAccount(int user_id);
    }
}
