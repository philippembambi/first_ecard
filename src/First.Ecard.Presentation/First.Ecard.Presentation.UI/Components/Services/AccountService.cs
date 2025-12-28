using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.Models;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class AccountService
    {
        private readonly HttpClient _http;

        public AccountService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<AccountResponse>> GetAccountsAsync()
        {
            return await _http.GetFromJsonAsync<List<AccountResponse>>("Accounts") ?? new List<AccountResponse>();
        }

        // public async Task<HttpResponseMessage> AddClientAsync(ClientRequest clientRequest)
        // {
        //     var response = await _http.PostAsJsonAsync("Client", clientRequest);
        //     return response;
        // }
    }
}