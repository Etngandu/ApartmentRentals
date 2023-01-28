using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    public class Apartment_booking : DomainEntity<int>,IDateTracking
    {

        public int ApartmentId { get; set; }
        public Apartment ?Apartment { get; set; }    
        public int GuestId { get; set; }
        public Guest ?Guest { get; set; }
        public int ?Apartment_BuildingId { get; set; }
        public Apartment_Building ?Apartment_Building { get; set; }
        public Ref_Booking_status Booking_status_code { get; set; }
        public DateTime Booking_start_date { get; set; }
        public DateTime Booking_end_date { get; set; }
        public string? Other_booking_details { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateModified { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
