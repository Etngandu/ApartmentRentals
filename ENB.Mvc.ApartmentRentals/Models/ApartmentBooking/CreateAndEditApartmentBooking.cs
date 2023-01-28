using ENB.ApartmentRentals.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class CreateAndEditApartmentBooking: IValidatableObject
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }

        [DisplayName("Guest Name")]
        public int GuestId { get; set; }       
        public int? Apartment_BuildingId { get; set; }

        [DisplayName("Booking status code")]
        public Ref_Booking_status Booking_status_code { get; set; }

        [DisplayName("Booking start date")]
        public DateTime Booking_start_date { get; set; }

        [DisplayName("Booking end date")]
        public DateTime Booking_end_date { get; set; }

        [DisplayName("Other booking details")]
        public string? Other_booking_details { get; set; }
        public List<SelectListItem>? ListGuests { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Booking_status_code == Ref_Booking_status.None)
            {
                yield return new ValidationResult("Booking_status_code can't be None.", new[] { "Booking_status_code" });
            }
        }
    }
}
