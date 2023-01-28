using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;

namespace ENB.ApartmentRentals.EF.ConfigurationEntity
{
   public class Apartment_BuildingConfiguration : IEntityTypeConfiguration<Apartment_Building>
    {
        public void Configure(EntityTypeBuilder<Apartment_Building> builder)
        {
            builder.Property(x => x.Building_short_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Building_full_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Building_description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Building_address).IsRequired().HasMaxLength(350);
            builder.Property(x => x.Building_full_name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Building_manager).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Building_phone).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Other_buiding_details).IsRequired().HasMaxLength(300);
           
        }
    }
}
