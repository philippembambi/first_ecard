using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using First.Ecard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using First.Ecard.Domain.Enums;

namespace First.Ecard.Infrastructure.Persistence.Configurations
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
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

            builder.Property(a => a.Role)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(a => a.PasswordHash)
                .HasMaxLength(255);

            builder.Property(a => a.MatriculationNumber)
                .IsRequired()
                .HasMaxLength(255);

            // builder.HasData(
            // new Agent("Philippe", "Mbambi", GenderType.M, "Kinshasa", "826686661", "philippembambi413@gmail.com", AgentRole.Admin)
            // {
            //     Age = 26,
            //     DateOfBirth = new DateTime(1999, 6, 5),
            //     Nationality = "Congolese",
            //     Password = "Phil123",
            //     MatriculationNumber = "AGENT-0001",
            //     LastLogin = DateTime.UtcNow
            // },
            // new Agent("Jackson", "Mbambi", GenderType.M, "Kinshasa", "826686661", "jackson@gmail.com", AgentRole.Support)
            // {
            //     Age = 26,
            //     DateOfBirth = new DateTime(1996, 5, 12),
            //     Nationality = "Congolese",
            //     Password = "Jack123",
            //     MatriculationNumber = "AGENT-0002",
            //     LastLogin = DateTime.UtcNow
            // }
            // );
        }
    }
}