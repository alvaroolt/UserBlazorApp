﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebServiceApiRest.Models;
using WebServiceApiRest.Models.Response;

namespace UserBlazorApp.Services
{
    public interface IServiceComprobarSiExisteMesa
    {
        Task<Respuesta> DameDocumentos(int orden);
    }
}