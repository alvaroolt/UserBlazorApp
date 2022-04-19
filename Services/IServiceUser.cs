using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public interface IServiceUser
    {
        Task<IEnumerable<User>> DameUsers();
        Task<IEnumerable<User>> DameUser(int id);
    }
}
