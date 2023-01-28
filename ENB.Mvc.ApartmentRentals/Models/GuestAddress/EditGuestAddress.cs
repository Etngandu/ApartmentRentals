using System.ComponentModel.DataAnnotations;
using System.IO;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Entities;

namespace ENB.Mvc.ApartmentRentals.Models
{
    public class EditGuestAddress : IValidatableObject
    {
        public int Id { get; set; }
        public string? Number_street { get; set; }        
        public string? City { get; set; }        
        public string? Zipcode { get; set; }        
        public string? State_province_county { get; set; }        
        public string? Country { get; set; }       
        public int GuestId { get; set; }
        public Guest? Guest { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //return new GuestAddress(Number_street, City, Zipcode,State_province_county,
            //    Country ).Validate();
            if (string.IsNullOrEmpty(City))
            {
                yield return new ValidationResult("City can't be None.", new[] { "City" });
            }
        }
    }
}
