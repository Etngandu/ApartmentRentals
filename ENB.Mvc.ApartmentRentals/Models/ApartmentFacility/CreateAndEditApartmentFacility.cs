using ENB.ApartmentRentals.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class CreateAndEditApartmentFacility : IValidatableObject
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public int Apartment_BuildingId { get; set; }
        public Apartment_Building? Apartment_Building { get; set; }
        public Ref_Apartment_facility Facilitycode { get; set; }
        public string? Other_facility_details { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(Facilitycode==Ref_Apartment_facility.None)
            {
                yield return new ValidationResult("Facilitycode can't be None.", new[] { "Facilitycode" });
            }
        }
    }
}
