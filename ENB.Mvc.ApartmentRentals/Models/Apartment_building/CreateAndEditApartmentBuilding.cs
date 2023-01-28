using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class CreateAndEditApartmentBuilding:IValidatableObject
    {
        public int Id { get; set; }
        [Required, DisplayName("Building short name")]
        public string? Building_short_name { get; set; }

        [Required, DisplayName("Building full name")]
        public string? Building_full_name { get; set; }

        [DisplayName("Building description")]
        public string? Building_description { get; set; }

        [ DisplayName("Building address")]
        public string? Building_address { get; set; }

        [DisplayName("Building manager")]
        public string? Building_manager { get; set; }
        [DisplayName("Building phone")]
        public string? Building_phone { get; set; }

        [ DisplayName("Other buiding details")]
        public string? Other_buiding_details { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Building_address))
            {
                yield return new ValidationResult("Address can't be None.", new[] { "Building_address" });
            }
        }
    }
}
