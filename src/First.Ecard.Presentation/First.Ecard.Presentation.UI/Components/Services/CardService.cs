using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Presentation.UI.Components.Models;

namespace First.Ecard.Presentation.UI.Components.Services
{
    public class CardService
    {
        private readonly HttpClient _http;

       public CardService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<CardResponse>> GetCardsAsync()
        {
            return await _http.GetFromJsonAsync<List<CardResponse>>("Cards") ?? new List<CardResponse>();
        }
    }
}