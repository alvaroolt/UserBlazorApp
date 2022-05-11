using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebServiceApiRest.Models;
using WebServiceApiRest.Models.Response;

namespace UserBlazorApp.Services
{
    public class ServiceEliminarMesa : IServiceEliminarMesa
    {
        private readonly HttpClient httpClient;
        Respuesta oRespuesta = new Respuesta();
        public ServiceEliminarMesa(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task BorrarMesa(int mesa)
        {
            //await httpClient.DeleteAsync("api/ComprobarSiExisteMesa?mesa=" + mesa);
            var response = await httpClient.DeleteAsync("api/ComprobarSiExisteMesa?mesa=" + mesa);
            oRespuesta = response.Content.ReadFromJsonAsync<Respuesta>().Result;
        }
    }
}
