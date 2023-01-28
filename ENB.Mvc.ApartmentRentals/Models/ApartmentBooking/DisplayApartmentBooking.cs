using ENB.ApartmentRentals.Entities;
using System.ComponentModel;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class DisplayApartmentBooking
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
        public string? NameBuilding { get; set; }
        public string? NameGuest { get; set; }
        public int ApartNumber { get; set; }
    }
}
