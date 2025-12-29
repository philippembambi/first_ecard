using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using First.Ecard.Domain.Exceptions;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string AccountNumber { get; set; } = string.Empty;
        public AccountTypeEnum AccountType { get; set; }
        public decimal Balance { get; set; }
        public CurrencyType Currency { get; set; }
        public AccountStatus Status { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<Card> Cards { get; set; } = [];

        public bool IsActiveStatus() => Status == AccountStatus.Active;
        public bool IsSuspendedStatus() => Status == AccountStatus.Suspended;
        public static bool IsPositiveAmount(decimal amount) => amount > 0;
        public bool IsBalanceSufficient(decimal amount) => Balance >= amount;

        public void Withdraw(decimal amount)
        {
            if (!IsActiveStatus())
                throw new AccountException("Account is not active.");

            if (!IsPositiveAmount(amount))
                throw new AccountException("Withdrawal amount must be positive.");

            if (!IsBalanceSufficient(amount))
                throw new AccountException("Insufficient Balance.");

            Balance -= amount;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Deposit(decimal amount)
        {
            if (!IsActiveStatus())
                throw new AccountException("Account is not active.");

            if (!IsPositiveAmount(amount))
                throw new AccountException("Deposit amount must be positive.");

            Balance += amount;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SuspendAccount()
        {
            if (!IsActiveStatus())
                throw new AccountException("Only active accounts can be suspended.");

            Status = AccountStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }
        public void ReactivateAccount()
        {
            if (!IsSuspendedStatus())
                throw new AccountException("Only suspended accounts can be reactivated.");

            Status = AccountStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }
        public static string GenerateAccountNumber()
        {
            return string.Concat("FB-", DateTime.UtcNow.Ticks.ToString().Substring(1, 15));
        }
    }
}