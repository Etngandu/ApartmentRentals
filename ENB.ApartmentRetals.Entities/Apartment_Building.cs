using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRetals.Infrastructure;

namespace ENB.ApartmentRentals.Entities
{
    public class Apartment_Building : DomainEntity<int>, IDateTracking
    {
        public Apartment_Building()
        {
            Apartments = new Apartments();
            Apartment_Facilities = new Apartment_facilities();
            Apartment_Bookings = new Apartment_Bookings();
        }
        public string? Building_short_name { get; set; }
        public string? Building_full_name { get; set; }
        public string? Building_description { get; set; }
        public string? Building_address { get; set; }
        public string? Building_manager { get; set; }
        public string? Building_phone { get; set; }
        public string? Other_buiding_details { get; set; }

        public Apartments Apartments { get; set; }

        public Apartment_facilities Apartment_Facilities { get; set; }

        public Apartment_Bookings Apartment_Bookings  { get; set; }

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
            if (string.IsNullOrEmpty(Building_address))
            {
                yield return new ValidationResult("Street can't be null or empty", new[] { "Building_address" });
            }
        }
    }
}
