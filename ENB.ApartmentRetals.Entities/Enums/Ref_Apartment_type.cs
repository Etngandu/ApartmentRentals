using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ENB.ApartmentRentals.Entities
{
    /// <summary>
    /// Determines the type of a contact record.
    /// </summary>
    public enum Ref_Apartment_type
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a Studio.
        /// </summary>        
        Studio = 1,

        /// <summary>
        /// Indicates an Alcove_studio.
        /// </summary>  
        /// 
        [Display(Name = "Alcove studio")]
        Alcove_studio = 2,

        /// <summary>
        /// Indicates an apartment.
        /// </summary>        
        apartment = 3,

        /// <summary>
        /// Indicates a Micro_apartment.
        /// </summary>    
        /// 
        [Display(Name = "Micro apartment")]
        Micro_apartment = 4,

        /// <summary>
        /// Indicates a Loft.
        /// </summary>        
        Loft = 5,

        /// <summary>
        /// Indicates a Duplex.
        /// </summary>        
        Duplex = 6,

            /// <summary>
            /// Indicates a Triplex.
            /// </summary>        
        Triplex = 7


    }
}
