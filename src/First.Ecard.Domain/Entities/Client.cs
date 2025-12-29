using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Domain.Entities
{
    public class Client : User
    {
        public IDCardTypeEnum IDCardType { get; set; }
        public string IDCardNumber { get; set; } = string.Empty;

        public ICollection<Account> Accounts { get; set; } = [];
        public static int CalculateAge(DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dateOfBirth.Year;

            // Si l'anniversaire n'est pas encore passé cette année
            if (dateOfBirth.AddYears(age) > today)
            {
                age--;
            }

            return age;
        }
    }
}