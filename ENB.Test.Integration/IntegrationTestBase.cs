
using System.Diagnostics.CodeAnalysis;
using ENB.ApartmentRentals.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ENB.Test.Integration
{
  [ExcludeFromCodeCoverage]
  public class IntegrationTestBase
  {
    public IntegrationTestBase()
    {
            string ctr = "Server=desktop-chqki35\\SQLEXPRESS01;Database=ApartmentRentals;Trusted_Connection=True;MultipleActiveResultSets=true;";
           
             var optionbldr = new DbContextOptionsBuilder<ApartmentRentalsContext>();
            optionbldr.UseSqlServer(ctr);
    }
  }
}
