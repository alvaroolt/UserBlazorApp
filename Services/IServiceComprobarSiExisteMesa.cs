using System.Collections.Generic;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Services
{
    public interface IServiceComprobarSiExisteMesa
    {
        Task<IEnumerable<Documentos>> DameDocumentos(int orden);
    }
}