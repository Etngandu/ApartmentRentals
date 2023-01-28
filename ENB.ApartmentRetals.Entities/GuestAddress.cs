using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ENB.ApartmentRetals.Entities;
using ENB.ApartmentRetals.Infrastructure;

namespace ENB.ApartmentRentals.Entities
{
    public class GuestAddress : DomainEntity<int>, IDateTracking
    {

        /// <summary>
        /// Initializes a new instance of the Address class.
        /// The constructor is marked private because we want other consuming code to use the overloaded constructor.
        /// However, EF still needs a parameterless constructor.
        /// </summary>
        //public GuestAddress() { }
        //public GuestAddress(string? number_street, string? city, string? zipcode, string? state_province_county, string? country)
        //{
        //    Number_street = number_street;
        //    City = city;
        //    Zipcode = zipcode;
        //    State_province_county = state_province_county;
        //    Country = country;
        //}
        #region Constructors
        //public GuestAddress(string? number_street, string? city, string? zipcode, string? state_province_county, string? country, Guest? guest, int guestId, DateTime dateCreated, DateTime dateModified)
        //{
        //    Number_street = number_street;
        //    City = city;
        //    Zipcode = zipcode;
        //    State_province_county = state_province_county;
        //    Country = country;            
        //}
        #endregion


        /// <summary>
        /// Gets or sets the Number_street of the Customer.
        /// </summary>
        /// 
        public string? Number_street { get;  set; }

        /// <summary>
        /// Gets or sets the City of the Customer.
        /// </summary>
        /// 
        public string? City { get;  set; }
        /// <summary>
        /// Gets or sets the Zipcode of the Customer.
        /// </summary>
        /// 
        public string? Zipcode { get; set; }

        /// <summary>
        /// Gets or sets the State_province_county of the Customer.
        /// </summary>
        /// 
        public string? State_province_county { get; set; }

        /// <summary>
        /// Gets or sets the Country of the Customer.
        /// </summary>
        /// 
        public string? Country { get; set; }

        public Guest? Guest { get; set; }
        public int GuestId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Determines if this address can be considered to represent a "null" value.
        /// </summary>
        // <returns>True when all four properties of the address contain null; false otherwise. 
        public bool IsNull
        {
            get
            {
                return (string.IsNullOrEmpty(Number_street) && string.IsNullOrEmpty(Zipcode)
                    && string.IsNullOrEmpty(City) && string.IsNullOrEmpty(Country) &&
                    string.IsNullOrEmpty(State_province_county));
            }
        }

        #region Methods

        /// <summary>
        /// Validates this object. 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsNull)
            {                
                if (string.IsNullOrEmpty(Number_street))
                {
                    yield return new ValidationResult("Street can't be null or empty", new[] { "Number_street" });
                }
                if (string.IsNullOrEmpty(Zipcode))
                {
                    yield return new ValidationResult("ZipCode can't be null or empty", new[] { "Zipcode" });
                }
                if (string.IsNullOrEmpty(City))
                {
                    yield return new ValidationResult("City can't be null or empty", new[] { "City" });
                }
                if (string.IsNullOrEmpty(State_province_county))
                {
                    yield return new ValidationResult("Country can't be null or empty", new[] { "State_province_county" });
                }
                if (string.IsNullOrEmpty(Country))
                {
                    yield return new ValidationResult("Country can't be null or empty", new[] { "Country" });
                }
            }
        }
        #endregion
    }
}
