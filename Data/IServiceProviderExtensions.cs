using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBlazorApp.Data
{
    public static class IServiceProviderExtensions
    {
        // interfaz para iniciar/cerrar sesión
        public static T Get<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T).BaseType);
    }
}
