using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.EF.Repositories
{
    /// <summary>
    /// A concrete repository to work with case in the system.
    /// </summary>
    public class AsyncApartBuildingRepository: AsyncRepository<Apartment_Building>, IAsyncApartBuildingRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly ApartmentRentalsContext _apartmentRentalsContext;
        public AsyncApartBuildingRepository(ApartmentRentalsContext apartmentRentalsContext) : base(apartmentRentalsContext)
        {
            _apartmentRentalsContext = apartmentRentalsContext;
        }
        public IEnumerable<Apartment_Building> FindByName(string lastname)
        {
            return _apartmentRentalsContext.Set<Apartment_Building>().Where(x => x.Building_short_name == lastname);
        }
    }
}
