using ENB.ApartmentRetals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.Entities.Repositories
{
    /// <summary>
    /// Defines the various methods available to work with Apartment in the system.
    /// </summary>
    public interface IAsyncApartBuildingRepository : IAsyncRepository<Apartment_Building, int>
    {
        /// <summary>
        /// Gets a list of all the people whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Apartment_Building with the matching apartment.</returns>

        IEnumerable<Apartment_Building> FindByName(string name);
    }
}
