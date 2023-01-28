using BlazorApp.Models;
using BlazorApp.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BlazorApp.Data
{
    public class Auth : AuthenticationStateProvider
    {
        //private readonly ProtectedSessionStorage _protectedSessionStorage;

        private User _user = null;

        //public Auth(ProtectedSessionStorage protectedSessionStorage)
        //{
        //    _protectedSessionStorage = protectedSessionStorage;
        //}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(_user == null)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Email , _user.Email),
                new Claim(ClaimTypes.Role, _user.Role)
            }, "Auth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            //try
            //{
            //    var userSessionStorageResult = await _protectedSessionStorage.GetAsync<User>("User");
            //    var user = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
            //    if (user == null)
            //    {
            //        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            //    }
            //    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Email , user.Email),
            //        new Claim(ClaimTypes.Role, user.Role)
            //    }, "Auth"));
            //    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            //}
            //catch(Exception ex)
            //{
            //    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

            //}

        }
        public async Task UpdateAuthenticationState(User user)
        {
            if(user == null)
            {
                //await _protectedSessionStorage.DeleteAsync("User");
                _user = null;

            }
            _user = user;
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Email , _user.Email),
                new Claim(ClaimTypes.Role, _user.Role)
            }, "Auth"));
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));    

        }
    }
}
