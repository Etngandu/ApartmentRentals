using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRentals.EF;
using ENB.ApartmentRetals.Infrastructure;
using FluentAssertions.Execution;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using ENB.Test.Integration;
using ENB.ApartmentRentals.EF.Repositories;
using System.Runtime.CompilerServices;

namespace Spaanjaars.ContactManager45.Tests.Integration
{
  [TestClass]
  [ExcludeFromCodeCoverage]
  public class ContactManagerContextTests :IntegrationTestBase
    {
        
        [SetUp]

       
        public void Setup()
        {
            var optionbuilder = new DbContextOptionsBuilder<ApartmentRentalsContext>()
               .UseInMemoryDatabase(databaseName: "Apart Test")
                         .Options;
        }

        

        [Test]
        public void CanAddGuestUsingApartmentRentalsContext()
    {


            //var optionbuilder = new DbContextOptionsBuilder<ApartmentRentalsContext>()
            //    .UseInMemoryDatabase(databaseName: "Apart Test")
            //              .Options;

            string ctr = "Server=desktop-chqki35\\SQLEXPRESS01;Database=ApartmentRentals;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var optionbldr = new DbContextOptionsBuilder<ApartmentRentalsContext>();
            var opt = optionbldr.UseSqlServer(ctr)
                .Options;

            //var person = new Person { FirstName = "Imar", LastName = "Spaanjaars", DateOfBirth = new DateTime(1971, 8, 9), DateCreated = DateTime.Now, DateModified = DateTime.Now, Type = PersonType.Colleague, HomeAddress = AddressTests.CreateAddress(ContactType.Personal), WorkAddress = AddressTests.CreateAddress(ContactType.Business) };
            var guest = new Guest { Guest_first_name = "Etienne", Guest_last_name = "Ngandu", Gender_code = Gender.Male, Date_of_birth = new DateTime(1971, 8, 9), Other_guest_details = "Test" };
            var context = new ApartmentRentalsContext(opt);
          
         context.Guests.Add(guest);
            //context.People.Add(person);
            //context.SaveChanges();
            context.SaveChanges();
    }
        [Test]
        public async Task CanAddGuestUsingRepositoryApartmentRentals()
        {


            //var optionbuilder = new DbContextOptionsBuilder<ApartmentRentalsContext>()
            //    .UseInMemoryDatabase(databaseName: "Apart Test")
            //              .Options;

            string ctr = "Server=desktop-chqki35\\SQLEXPRESS01;Database=ApartmentRentals;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var optionbldr = new DbContextOptionsBuilder<ApartmentRentalsContext>();
            var opt = optionbldr.UseSqlServer(ctr)
                .Options;

            //var person = new Person { FirstName = "Imar", LastName = "Spaanjaars", DateOfBirth = new DateTime(1971, 8, 9), DateCreated = DateTime.Now, DateModified = DateTime.Now, Type = PersonType.Colleague, HomeAddress = AddressTests.CreateAddress(ContactType.Personal), WorkAddress = AddressTests.CreateAddress(ContactType.Business) };
            var guest = new Guest { Guest_first_name = "EtienneRepoEfwk", Guest_last_name = "Ngandu", Gender_code = Gender.Male, Date_of_birth = new DateTime(1971, 8, 9), Other_guest_details = "Test", DateCreated = DateTime.Now, DateModified = DateTime.Now };
            var context = new ApartmentRentalsContext(opt);
            var repo = new AsyncGuestRepository(context);
          // await repo.Add(guest);    
            var unitofwk= new AsyncEFUnitOfWork(context);
          await   unitofwk.Commit();
           // context.Guests.Add(guest);
            //context.People.Add(person);
            //context.SaveChanges();
           // context.SaveChanges();
        }

        [Test]
        public void CanExecuteQueryAgainstDataContext()
        {
            var optionbuilder = new DbContextOptionsBuilder<ApartmentRentalsContext>()
               .UseInMemoryDatabase(databaseName: "Apart Test")
                         .Options;

            string ctr = "Server=desktop-chqki35\\SQLEXPRESS01;Database=ApartmentRentals;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var optionbldr = new DbContextOptionsBuilder<ApartmentRentalsContext>();
            var opt = optionbldr.UseSqlServer(ctr)
                .Options;


            string lastName = Guid.NewGuid().ToString().Substring(0, 25);
            var context =new ApartmentRentalsContext(opt);
            var guest = new Guest { Guest_first_name = "Etienne1", Guest_last_name = lastName, Gender_code = Gender.Male, Date_of_birth = new DateTime(1971, 8, 9), Other_guest_details = "Test" };
            context.Add(guest);
            context.SaveChanges();

            var personCheck = context.Guests.First(x => x.Guest_last_name == lastName);
            personCheck.Should().NotBeNull();
        }

        //[TestMethod]
        //public void ValidationErrorsThrowModelValidationException()
        //{
        //  var uow = new EFUnitOfWorkFactory().Create();
        //  Action act = () =>
        //    {
        //      var repo = new PeopleRepository();
        //      repo.Add(new Person());
        //      uow.Commit(true);
        //    };
        //  act.ShouldThrow<ModelValidationException>().WithMessage("The FirstName field is required", ComparisonMode.Substring);
        //  uow.Undo();
        //}
    }
}
