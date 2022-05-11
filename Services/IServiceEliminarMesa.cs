using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public interface IServiceEliminarMesa
    {
        Task BorrarMesa(int mesa);
    }
}