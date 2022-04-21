using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public class ServiceAccount : IServiceAccount
    {
        private readonly HttpClient httpClient;

        public ServiceAccount(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Account>> DameAccounts()
        {
            return await httpClient.GetFromJsonAsync<Account[]>("api/account/0");
        }

        public async Task<IEnumerable<Account>> DameAccount(int user_id)
        {
            return await httpClient.GetFromJsonAsync<Account[]>("api/account/" + user_id);
        }
    }
}
