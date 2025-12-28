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

        public async Task<HttpResponseMessage> AddAccountAsync(AccountRequest accountRequest)
        {
            var response = await _http.PostAsJsonAsync("Accounts", accountRequest);
            return response;
        }

        public async Task<List<AccountTypesResponse>> GetAccountTypesAsync()
        {
            return await _http.GetFromJsonAsync<List<AccountTypesResponse>>("Accounts/account_types") ?? new List<AccountTypesResponse>();
        }

        public async Task<List<CurrencyResponse>> GetCurrencyAsync()
        {
            return await _http.GetFromJsonAsync<List<CurrencyResponse>>("Accounts/currencies") ?? new List<CurrencyResponse>();
        }
    }
}