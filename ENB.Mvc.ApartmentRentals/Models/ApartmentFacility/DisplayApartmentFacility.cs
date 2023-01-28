using ENB.ApartmentRentals.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class DisplayApartmentFacility 
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
        public int Apartment_BuildingId { get; set; }
        public Apartment_Building? Apartment_Building { get; set; }
        public Ref_Apartment_facility Facilitycode { get; set; }
        public string? Other_facility_details { get; set; }
    }
}
