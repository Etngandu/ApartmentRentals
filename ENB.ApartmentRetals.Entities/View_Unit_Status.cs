using ENB.ApartmentRetals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    public class View_Unit_Status : DomainEntity<int>
    {
        public int Apartment_id { get; set; }
        public int Apartment_Booking_Id { get; set; }
        public DateTime status_Date { get; set; }
        public RefView_Unit_Status Unit_Status { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
