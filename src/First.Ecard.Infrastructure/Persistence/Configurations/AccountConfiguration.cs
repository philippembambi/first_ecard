using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using First.Ecard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace First.Ecard.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AccountNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Balance)
                .HasPrecision(18, 2);

            builder.Property(a => a.Currency)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(a => a.AccountType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(a => a.Client)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.ClientId);

            builder.HasMany(a => a.Cards)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId);
        }
    }
}