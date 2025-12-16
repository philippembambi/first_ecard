using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.interfaces;
using First.Ecard.Presentation.UI.Components.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigation;

        public LoginService(HttpClient http, NavigationManager navigation)
        {
            _http = http;
            _navigation = navigation;
        }
        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("", request);
            if (!response.IsSuccessStatusCode)
                return false;
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();            
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {result!.AccessToken}");

            return true;
        }

        public Task LogoutAsync()
        {
            _navigation.NavigateTo("/login", true);
            return Task.CompletedTask;
        }
    }
}