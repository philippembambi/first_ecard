using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using First.Ecard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace First.Ecard.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Gender)
                .IsRequired()
                .HasMaxLength(1)
                .HasConversion<string>();

            builder.Property(a => a.Email)
                .HasMaxLength(255);

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(255);

            builder.Property(a => a.Nationality)
                .HasMaxLength(255);

            builder.Property(a => a.Address)
                .HasMaxLength(255);
            
            builder.Property(a => a.Age)
                .HasMaxLength(3);

            builder.Property(a => a.IDCardType)
                .IsRequired();

            builder.Property(a => a.IDCardNumber)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(a => a.Accounts)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientId);
        }
    }
}