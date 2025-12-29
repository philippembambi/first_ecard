using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class LoginResponse
    {
        public string? AccessToken {get;set;}
        public string? FullName {get;set;}
        public string? Role {get;set;}
    }
}