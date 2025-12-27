using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class AccountResponse
    {
        public int Id { get; set;}
        public string accountNumber { get; set;} = string.Empty;
        public string accountType { get; set;} = string.Empty;
        public string balance { get; set;} = string.Empty;
        public string currency { get; set;} = string.Empty;
        public string status { get; set;} = string.Empty;
        public int Age { get; set;}
        public string DateOfBirth { get; set;} = string.Empty;
        public string Nationality { get; set;} = string.Empty;
        public string Address { get; set;} = string.Empty;
        public string PhoneNumber { get; set;} = string.Empty;
        public string Email { get; set;} = string.Empty; 
        public string CreatedAt { get; set;} = string.Empty;
    }
}