
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRentals.EF;
using ENB.ApartmentRetals.Entities;
using LawyerOffice.Data.EF.ConfigurationEntity;

namespace ENB.ApartmentRentals.EF
{
    /// <summary>
    /// This is the main DbContext to work with data in the database.
    /// </summary>
    public class ApartmentRentalsContext : DbContext
    {
        

        public ApartmentRentalsContext(DbContextOptions<ApartmentRentalsContext> options)
           : base(options)
        {

        }



        public DbSet<Apartment_Building> Apartment_Buildings { get; set; }
        public DbSet<Guest> Guests { get; set; }
      //  public DbSet<Apartment> Apartments { get; set; }


        /// <summary>
        /// Hooks into the Save process to get a last-minute chance to look at the entities and change them. Also intercepts exceptions and 
        /// wraps them in a new Exception type.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        /// 

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            var orphanedObjects = ChangeTracker.Entries().Where(
              e => (e.State == EntityState.Modified || e.State == EntityState.Added));




            //foreach (var orphanedObject in orphanedObjects)
            //{
            //    OwnerValidator.ValidateEntity(this, orphanedObject, orphanedObject.Entity.GetType());

            //}
            // SaveChangesExtensions.SaveChangesWithValidation(this);
            try
            {
                var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                foreach (EntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            changedOrAddedItem.DateCreated = DateTime.Now;
                        }
                        changedOrAddedItem.DateModified = DateTime.Now;
                    }
                    ////var valProvider = new ValidationDbContextServiceProvider(this);
                    ////var validationContext = new ValidationContext(item, valProvider, null);
                    ////Validator.ValidateObject(item, validationContext);

                }
                // return base.SaveChanges();
            }
            catch (Exception e)
            {

                // throw new ModelValidationException(result.ToString(), entityException, allErrors);
                var exStatus = SaveChangesExtensions.SaveChangesExceptionHandler(e, this);
                if (exStatus == null) throw;       //error wasn't handled, so rethrow
                var status = SaveChangesExtensions.ExecuteValidation(this);
                status.CombineStatuses(exStatus);
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }

        //private string cstr = "Server=desktop-chqki35\\sqlexpress01;Database=LawyerEFCore;Trusted_Connection=True;MultipleActiveResultSets=true;";
        ///// <summary>
        ///// Configures the EF context.
        ///// </summary>
        ///// <param name="modelBuilder">The model builder that needs to be configured.</param>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// 

        //private string cstr = "Server=desktop-chqki35\\sqlexpress01;Database=ApartmentRentals;Trusted_Connection=True;MultipleActiveResultSets=true;";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(cstr, b =>
        //         b.MigrationsAssembly("ENB.ApartmentRentals.EF"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           // modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        


    }
}
