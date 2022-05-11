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
    public class ServiceComprobarSiExisteMesa : IServiceComprobarSiExisteMesa
    {
        private readonly HttpClient httpClient;
        public Respuesta oRespuesta = new Respuesta();

        public ServiceComprobarSiExisteMesa(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //public async Task<IEnumerable<Documentos>> DameDocumentos(int orden)
        //{
        //    return await httpClient.GetFromJsonAsync<Documentos[]>("api/ComprobarSiExisteMesa?orden=" + orden);
        //}
        public async Task<Respuesta> DameDocumentos(int orden)
        {
            return await httpClient.GetFromJsonAsync<Respuesta>("api/ComprobarSiExisteMesa?orden=" + orden);
        }
    }
}
