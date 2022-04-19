using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public class ServiceUser:IServiceUser
    {
        private readonly HttpClient httpClient;

        public ServiceUser(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> DameUsers()
        {
            return await httpClient.GetFromJsonAsync<User[]>("api/user/0");
        }

        public async Task<IEnumerable<User>> DameUser(int id)
        {
            return await httpClient.GetFromJsonAsync<User[]>("api/user/" + id);
        }

        public async Task Post()
        {

            User _user = new User() {name="" };

            await httpClient.PostAsJsonAsync("api/user", _user);
        }

    }
}
