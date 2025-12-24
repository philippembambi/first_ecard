using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.interfaces;
using First.Ecard.Presentation.UI.Components.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NavigationManager _navigation;
        private readonly UserSessionService _userSession;

        public LoginService(HttpClient http, NavigationManager navigation, IHttpContextAccessor httpContextAccessor, UserSessionService userSession)
        {
            _http = http;
            _navigation = navigation;
            _httpContextAccessor = httpContextAccessor;
            _userSession= userSession;
        }

        public async Task<HttpResponseMessage> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("Login", request);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginResponse!.FullName),
                new Claim(ClaimTypes.Name, loginResponse!.Role)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal);

                _userSession.Setuser(loginResponse);
            }
            return response;
        }

        public async Task LogoutAsync()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            _navigation.NavigateTo("/login", true);
        }
    }
}