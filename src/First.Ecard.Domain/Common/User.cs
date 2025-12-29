using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Domain.Common
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GenderType Gender { get; set; }
        public int? Age { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public void UpdateContactInfo(string? newAddress, string? newPhoneNumber, string? newEmail)
        {
            if(!string.IsNullOrEmpty(newAddress))
                Address = newAddress;
            if(!string.IsNullOrEmpty(newPhoneNumber))
                PhoneNumber = newPhoneNumber;
            if(!string.IsNullOrEmpty(newEmail))
                Email = newEmail;
        }
    }
}