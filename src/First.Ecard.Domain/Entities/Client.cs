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

        public Client()
        {}
        public Client(IDCardTypeEnum idCardType, string idCardNumber, string firstName, string lastName, GenderType gender, DateTime dateOfBirth, string nationality, string address, string phoneNumber, string email, string cryptedPassword)
        {
            IDCardType = idCardType;
            IDCardNumber = idCardNumber;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = cryptedPassword;

            Age = CalculateAge(dateOfBirth);
            CreatedAt = DateTime.UtcNow;
        }
        public static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - dateOfBirth.Year;

            // Si l’anniversaire n’est pas encore passé cette année, on retire 1
            if (dateOfBirth.Date > today.AddYears(-age))
                age--;
            return age;
        }
    }
}