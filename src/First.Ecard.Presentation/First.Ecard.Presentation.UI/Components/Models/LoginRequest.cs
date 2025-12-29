using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email requis")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Email {get;set;} = string.Empty;

        [Required(ErrorMessage = "Mot de passe requis")]
        public string PasswordHash {get;set;} = string.Empty;
    }
}