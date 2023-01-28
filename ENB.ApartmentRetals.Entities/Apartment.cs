using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    public class Apartment : DomainEntity<int>, IDateTracking
    {
        public Apartment()
        {
            Apartment_Bookings = new Apartment_Bookings();
            Apartment_Facilities = new Apartment_facilities();
            View_Unit_Statuses = new View_Unit_Statuses();
        }
        public int Apartment_BuildingId { get; set; }
        public Apartment_Building? Apartment_Building { get; set; }
        public Ref_Apartment_type Ap_type { get; set; }
        public int Ap_number { get; set; }
        public int Bathroom_count { get; set; }
        public int Bedroom_count { get; set; }
        public int Room_count { get; set; }
        public string? Other_apartement_details { get; set; }

        public Apartment_Bookings Apartment_Bookings { get; set; }  

        public Apartment_facilities Apartment_Facilities { get; set; }

        public View_Unit_Statuses View_Unit_Statuses { get; set; }
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
            if (Ap_type == Ref_Apartment_type.None)
            {
                yield return new ValidationResult("Ref_Apartment_type can't be None.", new[] { "Apart_type" });
            }
        }
    }
}
