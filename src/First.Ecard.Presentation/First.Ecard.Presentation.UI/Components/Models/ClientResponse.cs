using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class ClientResponse
    {
        public int Id { get; set;}
        public string IdCardType { get; set;} = string.Empty;
        public string IdCardNumber { get; set;} = string.Empty;
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set;} = string.Empty;
        public string Gender { get; set;} = string.Empty;
        public int Age { get; set;}
        public string DateOfBirth { get; set;} = string.Empty;
        public string Nationality { get; set;} = string.Empty;
        public string Address { get; set;} = string.Empty;
        public string PhoneNumber { get; set;} = string.Empty;
        public string Email { get; set;} = string.Empty; 
        public string CreatedAt { get; set;} = string.Empty;
    }
    
}