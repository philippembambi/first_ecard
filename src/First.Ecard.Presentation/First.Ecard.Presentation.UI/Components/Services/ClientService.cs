using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.Models;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class ClientService
    {
       private readonly HttpClient _http;

       public ClientService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<ClientResponse>> GetClientAsync()
        {
            return await _http.GetFromJsonAsync<List<ClientResponse>>("Client") ?? new List<ClientResponse>();
        }

        public async Task<HttpResponseMessage> AddClientAsync(ClientRequest clientRequest)
        {
            var response = await _http.PostAsJsonAsync("Client", clientRequest);
            return response;
        }
    }
}