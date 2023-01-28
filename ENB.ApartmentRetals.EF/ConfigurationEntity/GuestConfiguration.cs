using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.ApartmentRetals.Infrastructure;
using ENB.ApartmentRentals.Entities;

namespace LawyerOffice.Data.EF.ConfigurationEntity
{
   public class GuestConfiguration:IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(x => x.Guest_first_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Guest_last_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(150);
            builder.Property(x => x.EmailAddres).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Other_guest_details).IsRequired().HasMaxLength(200);
                   
        }
    }
}
