using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Entities;
using System.ComponentModel.DataAnnotations;

namespace ENB.ApartmentRentals.Mvc.Models
{
    public class CreateAndEditGuest :IValidatableObject
    {
        public int Id { get; set; }
        public Gender Gender_code { get; set; }
        public string? Guest_first_name { get; set; }
        public string? Guest_last_name { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string? Other_guest_details { get; set; }

        public GuestAdress? GuestAdress { get; set; }

        public Apartment_Bookings? Apartment_Bookings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Gender_code == Gender.None)
            {
                yield return new ValidationResult("Gender_code can't be None.", new[] { "Gender_code" });
            }
        }
    }
}
