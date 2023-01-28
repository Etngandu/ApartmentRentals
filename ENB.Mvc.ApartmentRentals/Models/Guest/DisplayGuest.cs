using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class DisplayGuest
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
        public string? EmailAddres { get; set; }
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Gastenboek.
        /// </summary>
        [DisplayName("Other guest details")]
        public string? Other_guest_details { get; set; }

        public GuestAddress? GuestAdress { get; set; }

        public Apartment_Bookings? Apartment_Bookings { get; set; }

        /// <summary>
        /// Gets the full name of this person.
        /// </summary>
        public string? FullName { get; set; }
    }
}
