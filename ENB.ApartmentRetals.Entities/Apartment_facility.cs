using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    public class Apartment_facility : DomainEntity<int>, IDateTracking
    {
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public int Apartment_BuildingId { get; set; }
        public Apartment_Building? Apartment_Building { get; set; }
        public Ref_Apartment_facility Facilitycode { get; set; }
        public string? Other_facility_details { get; set; }

        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        public DateTime DateCreated { get; set ; }

        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        public DateTime DateModified { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Facilitycode == Ref_Apartment_facility.None)
            {
                yield return new ValidationResult("Facilitycode can't be None.", new[] { "Facilitycode" });
            }
        }
    }
}
