using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    /// <summary>
    /// Determines the type of a Ref_Apartment_facility record.
    /// </summary>
    public enum Ref_Apartment_facility
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates Car_Parking.
        /// </summary>
        /// 
        [Display(Name = "Car Parking")]
        Car_Parking = 1,

        /// <summary>
        /// Indicates Bike_Parking.
        /// </summary>
        ///
        [Display(Name = "Bike Parking")]
        Bike_Parking = 2,

        /// <summary>
        /// Indicates Swimming_Pool.
        /// </summary>
        /// 
        [Display(Name = "Swimming Pool")]
        Swimming_Pool = 3,

        /// <summary>
        /// Indicates Gym.
        /// </summary>
        /// 
        [Display(Name = "Gym")]
        Gym = 4,
        /// <summary>
        /// Indicates Concierge_And_Security.
        /// </summary>
        /// 
        [Display(Name = "Concierge And Security")]
        Concierge_And_Security = 5,

        /// <summary>
        /// Indicates Fitness Studios.
        /// </summary>
        ///
        [Display(Name = "Fitness Studios")]
        Fitness_Studios = 6,

        /// <summary>
        /// Indicates Conference Rooms.
        /// </summary>
        /// 
        [Display(Name = "Conference Rooms")]
        Conference_Rooms = 7,

        /// <summary>
        /// Indicates On-Site Restaurant.
        /// </summary>
        /// 
        [Display(Name = "On-Site Restaurant")]
        On_Site_Restaurant = 8,

        /// <summary>
        /// Indicates Green Space.
        /// </summary>
        ///
        [Display(Name = "Green Space")]
        Green_Space = 9,

        /// <summary>
        /// Indicates Co-Working Spaces.
        /// </summary>
        /// 
        [Display(Name = "Co-Working Spaces")]
        Co_Working_Spaces = 10,

        /// <summary>
        /// Indicates Laundry Room.
        /// </summary>
        /// 
        [Display(Name = "Laundry Room")]
        Laundry_Room = 11,

        /// <summary>
        /// Indicates WiFi In Common Areas.
        /// </summary>
        /// 
        [Display(Name = "WiFi In Common Areas")]
        WiFi_In_Common_Areas = 12
    }
}
