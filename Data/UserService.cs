using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using WebServiceApiRest.Models;

namespace UserBlazorApp.Data
{
    public class UserService : AuthenticationStateProvider
    {
        private const string USER_SESSION_OBJECT_KEY = "user_session_obj";

        // ProtectedSessionStorage permite almacenar y recuperar datos en la colección SessionStorage del explorador
        private ProtectedSessionStorage protectedSessionStore;
        // IHttpContextAccessor proporciona acceso a HttpContext
        private IHttpContextAccessor httpContextAccessor;

        public UserService(ProtectedSessionStorage protectedSessionStore, IHttpContextAccessor httpContextAccessor) =>
            (this.protectedSessionStore, this.httpContextAccessor) = (protectedSessionStore, httpContextAccessor);

        private Usuarios User { get; set; }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // lee un posible objeto de sesión de usuario desde el almacenamiento
            Usuarios userSession = await GetUserSession();

            // si hay sesión, llama al método que genera la autentificación
            if (userSession != null)
                return await GenerateAuthenticationState(userSession);
            //si no hay sesión, llama al método que genera la autentificación vacía
            return await GenerateEmptyAuthenticationState();
        }

        public async Task LoginAsync(Usuarios user)
        {
            // almacena la información de la sesión del usuario en el almacenamiento del cliente
            await SetUserSession(user);

            // notifica la autentificación de state provider
            NotifyAuthenticationStateChanged(GenerateAuthenticationState(user));
        }

        public async Task LogoutAsync()
        {
            // elimina el objeto de sesión del usuario
            await SetUserSession(null);

            // notifica la autentificación de state provider.
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }

        public async Task<Usuarios> GetUserSession()
        {
            // si existe el usuario, lo devuelve
            if (User != null)
                return User;

            string localUserJson = await protectedSessionStore.GetAsync<string>(USER_SESSION_OBJECT_KEY);

            // no active user session found!
            if (string.IsNullOrEmpty(localUserJson))
                return null;

            try
            {
                // refresca el usuario deserializado
                return RefreshUserSession(JsonConvert.DeserializeObject<Usuarios>(localUserJson));
            }
            catch
            {
                // el usuario podría haber modificado el valor local, lo que daría lugar a un objeto cifrado no válido.
                // Por lo tanto, el usuario destruye su propio objeto de sesión
                await LogoutAsync();
                return null;
            }
        }

        private async Task SetUserSession(Usuarios user)
        {
            // in order to avoid fetching the user object from JS.
            // almacena la sesión actual en el objeto del usuario para evitar obtener el objeto del usuario desde JavaScript
            RefreshUserSession(user);

            await protectedSessionStore.SetAsync(USER_SESSION_OBJECT_KEY, JsonConvert.SerializeObject(user));
        }

        // refresca la sesión del usuario
        private Usuarios RefreshUserSession(Usuarios user) => User = user;

        private Task<AuthenticationState> GenerateAuthenticationState(Usuarios user)
        {
            // ClaimsIdentity permite la autenticación basada en notificaciones o claims, donde la identidad del usuario se representa como un conjunto de notificaciones.
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.user_id.ToString()),
                new Claim(ClaimTypes.Role, user.user_rol.ToString())
            }, "apiauth_type");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        // genera una autenticación para un usuario nulo
        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
    }
}
