using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class AccountRequest
    {
        [Required(ErrorMessage = "Veillez renseigner le Type de compte")]
        public string AccountType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner la devise")]
        public string Currency { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le client associé")]
        public int ClientId { get; set; }
    }
}