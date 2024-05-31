using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Core.Entities;

    namespace Infrastructure.Configurations
    {
        public class TicketConfiguration : IEntityTypeConfiguration<Tickket>
        {
            public void Configure(EntityTypeBuilder<Tickket> builder)
            {
                builder.HasKey(e => e.Id);

                builder.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                builder.Property(e => e.Governorate)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(e => e.CreationDateTime)
                    .IsRequired();

                builder.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            }
        }
    }

}
