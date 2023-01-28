using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.ApartmentRetals.Infrastructure;
using ENB.ApartmentRentals.Entities;

namespace ENB.ApartmentRentals.EF.ConfigurationEntity
{
   public class Apartment_BookingConfiguration:IEntityTypeConfiguration<Apartment_booking>
    {
        public void Configure(EntityTypeBuilder<Apartment_booking> builder)
        {
            builder.Property(x => x.Other_booking_details).IsRequired().HasMaxLength(150);            
            
        }
    }
}
