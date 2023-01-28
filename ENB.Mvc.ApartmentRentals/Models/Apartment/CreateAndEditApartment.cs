using ENB.ApartmentRentals.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class CreateAndEditApartment : IValidatableObject
    {
        public int Id { get; set; }
        public int Apartment_BuildingId { get; set; }
        
        public Apartment_Building? Apartment_Building { get; set; }

        [Required, DisplayName("Apartment type")]
        public Ref_Apartment_type Ap_type { get; set; }

        [Required, DisplayName("Apartment Number")]
        public int Ap_number { get; set; }

        [Required, DisplayName("Bathroom count")]
        public int Bathroom_count { get; set; }

        [Required, DisplayName("Bedroom count")]
        public int Bedroom_count { get; set; }

        [Required, DisplayName("Room count")]
        public int Room_count { get; set; }
        public string? Other_apartement_details { get; set; }
        
        public List<SelectListItem>? ListAprtBld { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ap_type == Ref_Apartment_type.None)
            {
                yield return new ValidationResult("Apartment_type can't be None.", new[] { "Ap_type" });
            }
        }
    }
}
