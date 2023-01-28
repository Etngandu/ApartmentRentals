using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities
{
    public class Guest : DomainEntity<int>, IDateTracking
    {
        public Guest()
        {
            Apartment_Bookings = new Apartment_Bookings();
            GuestAddress= new GuestAddress();
        }

        public Gender Gender_code { get; set; }
        public string? Guest_first_name { get; set; }
        public string? Guest_last_name { get; set; }
        public DateTime Date_of_birth { get; set; }

        public string? EmailAddres { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Other_guest_details { get; set; }

        public GuestAddress GuestAddress { get; set; }

        public Apartment_Bookings Apartment_Bookings { get; set; }

        /// <summary>
        /// Gets the full name of this person.
        /// </summary>
        public string FullName
        {
            get
            {
                string temp = Guest_first_name ?? string.Empty;
                if (!string.IsNullOrEmpty(Guest_last_name))
                {
                    if (temp.Length > 0)
                    {
                        temp += " ";
                    }
                    temp += Guest_last_name;
                }
                return temp;
            }

           // set { _ = string.Empty; }
        }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date_of_birth < DateTime.Now.AddYears(Constants.MaxAgePerson * -1))
            {
                yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            }
            if (Date_of_birth > DateTime.Now)
            {
                yield return new ValidationResult("Invalid range for DateOfBirth; must be between today and 130 years ago.", new[] { "DateOfBirth" });
            }
        }
    }
}
