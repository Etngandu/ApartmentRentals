using ENB.ApartmentRetals.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities.Collections
{
    
    /// <summary>
    /// Represents a collection of People instances in the system.
    /// </summary>
    public class Guests : CollectionBase<Guest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Apartments"/> class.
        /// </summary>
        public Guests() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts an IList of Person as the initial list.</param>
        public Guests(IList<Guest> initialList) : base(initialList) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operators"/> class.
        /// </summary>
        /// <param name="initialList">Accepts a CollectionBase of Person as the initial list.</param>
        public Guests(CollectionBase<Guest> initialList) : base(initialList) { }

        /// <summary>
        /// Validates the current collection by validating each individual item in the collection.
        /// </summary>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var errors = new List<ValidationResult>();
            foreach (var guest in this)
            {
                errors.AddRange(guest.Validate());
            }
            return errors;
        }
    }
}
