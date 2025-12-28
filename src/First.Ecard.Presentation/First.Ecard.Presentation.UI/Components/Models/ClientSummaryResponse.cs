using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class ClientSummaryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}