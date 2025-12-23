using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class TokenStorageService
    {
        private readonly IJSRuntime _jS;
        private const string TokenKey = "auth_token";

        public TokenStorageService(IJSRuntime jS)
        {
            _jS = jS;
        }
        public async Task SetTokenAsync(string token)
        {
            await _jS.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _jS.InvokeAsync<string?>("localStorage.getItem", TokenKey);
        }

        public async Task RemoveTokenAsync()
        {
            await _jS.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        }
    }
}