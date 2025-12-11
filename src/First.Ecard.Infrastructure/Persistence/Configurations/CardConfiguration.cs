using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using First.Ecard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace First.Ecard.Infrastructure.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CardNumber)
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(a => a.CardType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(a => a.CVV)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(a => a.ExpiryDate)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.AccountId)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.HasOne(a => a.Account)
                .WithMany(c => c.Cards)
                .HasForeignKey(a => a.AccountId);
        }
    }
}