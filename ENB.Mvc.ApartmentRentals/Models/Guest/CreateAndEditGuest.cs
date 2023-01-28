using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class CreateAndEditGuest :IValidatableObject
    {
        public int Id { get; set; }

        [DisplayName("Gender")]
        public Gender Gender_code { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Guest.
        /// </summary>
        [Required, DisplayName("Guest First Name")]
        public string? Guest_first_name { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Guest.
        /// </summary>
        [Required, DisplayName("Guest Last Name")]
        public string? Guest_last_name { get; set; }

        [DisplayName("Date of birth")]
        public DateTime Date_of_birth { get; set; }

        [EmailAddress]
        public string? EmailAddres { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Other_guest_details { get; set; }

        public GuestAddress? GuestAdress { get; set; }

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
