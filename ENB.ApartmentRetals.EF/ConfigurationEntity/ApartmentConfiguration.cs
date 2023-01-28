using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;


namespace LawyerOffice.Data.EF.ConfigurationEntity
{
   public class ApartmentConfiguration:IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.Property(x => x.Ap_number).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Other_apartement_details).IsRequired().HasMaxLength(450);           
        }
    }
}
