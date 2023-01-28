using ENB.ApartmentRetals.Infrastructure;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ENB.ApartmentRentals.EF
{
    /// <summary>
    /// Defines a Unit of Work using an EF DbContext under the hood.
    /// </summary>
    public class AsyncEFUnitOfWork : IAsyncUnitOfWork
    {
       // private readonly IDataContextStorageContainer<InsuranceAndClaimsContext> _cdataContextFactory;

        private readonly ApartmentRentalsContext _apartmentRentalsContext;
        private bool _forceNew;
        private bool _disposed;

        // private InsuranceAndClaimsContext insuranceAndClaimsContext;

        /// <summary>
        /// Initializes a new instance of the EFUnitOfWork class.
        /// </summary>
        /// <param name="forceNewContext">When true, clears out any existing data context first.</param>

        public AsyncEFUnitOfWork(ApartmentRentalsContext apartmentRentalsContext)
        {
            
            _apartmentRentalsContext = apartmentRentalsContext ?? throw new ArgumentNullException(nameof(apartmentRentalsContext)); ;
        }

        public AsyncEFUnitOfWork(bool forceNew, ApartmentRentalsContext apartmentRentalsContext)
        {
            _forceNew = forceNew;
            _apartmentRentalsContext = apartmentRentalsContext;
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        //public  void Dispose()
        //{

        //     _apartmentRentalsContext.SaveChangesAsync();
        //}



        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        /// <param name="">When true, clears out the data context afterwards.</param>
        public async Task Commit()
        {
            
          await _apartmentRentalsContext.SaveChangesAsync();
                
        }

        

      public async ValueTask DisposeAsync()
        {
            //await _insuranceAndClaimsContext.DisposeAsync();
            // await DisposeAsync(true);
            await _apartmentRentalsContext.SaveChangesAsync();
            // Take this object off the finalization queue to prevent 
            // finalization code for this object from executing a second time.
            // GC.SuppressFinalize(this);
        }

        // <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing</param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    await _apartmentRentalsContext.DisposeAsync();
                }

                // Dispose any unmanaged resources here...

                _disposed = true;
            }
        }
    }
}
