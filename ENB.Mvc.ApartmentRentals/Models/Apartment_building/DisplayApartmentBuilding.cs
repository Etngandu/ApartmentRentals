using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class DisplayApartmentBuilding 
    {
        public int Id { get; set; }
       
        [DisplayName("Building short name")]
        public string? Building_short_name { get; set; }

        [DisplayName("Building full name")]
        public string? Building_full_name { get; set; }

        [DisplayName("Building description")]
        public string? Building_description { get; set; }

        [DisplayName("Building address")]
        public string? Building_address { get; set; }

        [DisplayName("Building manager")]
        public string? Building_manager { get; set; }
        [DisplayName("Building phone")]
        public string? Building_phone { get; set; }

        [DisplayName("Other buiding details")]
        public string? Other_buiding_details { get; set; }


    }
}
