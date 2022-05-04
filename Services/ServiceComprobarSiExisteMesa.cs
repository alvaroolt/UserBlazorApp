using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public class ServiceComprobarSiExisteMesa : IServiceComprobarSiExisteMesa
    {
        private readonly HttpClient httpClient;

        public ServiceComprobarSiExisteMesa(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Documentos>> DameDocumentos(int orden)
        {
            return await httpClient.GetFromJsonAsync<Documentos[]>("api/ComprobarSiExisteMesa?orden=" + orden);
        }
    }
}
