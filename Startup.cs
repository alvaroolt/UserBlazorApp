using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Syncfusion.Blazor;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using UserBlazorApp.Data;
using Blazored.LocalStorage;

namespace UserBlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(); // agrega servicios MVC para páginas al IServiceCollection especificado. https://docs.microsoft.com/es-es/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addrazorpages?view=aspnetcore-6.0
            services.AddServerSideBlazor(); // agrega server-side blazor a la colección de servicios
            services.AddAuthorization();
            services.AddAuthentication();
            services.AddProtectedBrowserStorage();
            services.AddScoped<AuthenticationStateProvider, UserService>();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddBlazoredSessionStorage();
            services.AddBlazoredLocalStorage();


            // AddHttpClient permite enviar solicitudes y recibir respuestas HTTP de un recurso identificado por un URI.
            //services.AddHttpClient<IServiceUser, ServiceUser>(user =>
            //{
            //    user.BaseAddress = new Uri("https://localhost:44327/"); //dirección de la API
            //});
            //services.AddHttpClient<IServiceAccount, ServiceAccount>(account =>
            //{
            //    account.BaseAddress = new Uri("https://localhost:44327/"); //dirección de la API
            //});
            //services.AddHttpClient<IServiceComprobarSiExisteMesa, ServiceComprobarSiExisteMesa>(comprobarSiExisteMesa =>
            //{
            //    comprobarSiExisteMesa.BaseAddress = new Uri("https://localhost:44327");
            //});
            //services.AddHttpClient<IServiceEliminarMesa, ServiceEliminarMesa>(eliminarMesa =>
            //{
            //    eliminarMesa.BaseAddress = new Uri("https://localhost:44327");
            //});
            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("http://192.168.1.185:44322")
            });
            services.AddSyncfusionBlazor(); // agrega el servicio de Syncfusion para Blazor
        }

        // Este método se llama en el runtime. Se usa para configurar las peticiones HTTP entre procesos
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Licencia para utilizar los servicios de Syncfusion
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkFjXn9acnNWRWZUVE0=;NjA5MDc0QDMyMzAyZTMxMmUzMGpuc2tpVE1kRU9ITjY2RzJyQm4yenlOUUlJSEFMME12NytrcWs5eDNaWXc9");

            // comprueba si el nombre del entorno de desarrollo actual es Producción
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
