using ENB.ApartmentRentals.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class DisplayApartment 
    {
        public int Id { get; set; }
        public int Apartment_BuildingId { get; set; }      

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

        public string? NameBuilding { get; set; }


    }
}
