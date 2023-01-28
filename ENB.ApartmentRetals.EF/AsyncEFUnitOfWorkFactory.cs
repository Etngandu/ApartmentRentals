using ENB.ApartmentRetals.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace ENB.ApartmentRentals.EF
{
  public  class AsyncEFUnitOfWorkFactory :IAsyncUnitOfWorkFactory
    {
        private readonly ApartmentRentalsContext _apartmentRentalsContext;

        public AsyncEFUnitOfWorkFactory(ApartmentRentalsContext apartmentRentalsContext)
        {
            _apartmentRentalsContext = apartmentRentalsContext;

        }
        public AsyncEFUnitOfWorkFactory(bool forcenew,ApartmentRentalsContext apartmentRentalsContext)
        {
            _apartmentRentalsContext = apartmentRentalsContext;
            
        }
        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        public async Task<IAsyncUnitOfWork> Create()
        {
            return await Create(false);
        }

        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing data context from the storage container.</param>
        public async Task<IAsyncUnitOfWork> Create(bool forceNew)
        {
            var asyncEFUnitOfWork = await Task.FromResult(new AsyncEFUnitOfWork(forceNew, _apartmentRentalsContext));


            return  asyncEFUnitOfWork;
           
        }

        
    }
}
