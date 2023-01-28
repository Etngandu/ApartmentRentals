using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRentals.Entities.Collections;

namespace ENB.TestUnits
{
  [TestClass]
  [ExcludeFromCodeCoverage]
  public class CollectionBaseTests : UnitTestBase
  {
    [Test]
    public void NewCollectionUsingNewListsAddsValues()
    {
      var collection = new IntCollection(new List<int> { 1, 2, 3 });
      collection.Count.Should().Be(3);
    }

    [Test]
    public void NewCollectionUsingExistingCollectionAddsValues()
    {
      var collection1 = new IntCollection(new List<int> { 1, 2, 3 });
      var collection2 = new IntCollection(collection1);
      collection2.Count.Should().Be(3);
    }

    [Test]
    public void UsingAddRangeAddsValues()
    {
      var collection1 = new IntCollection(new List<int> { 1, 2, 3 });
      var collection2 = new IntCollection();
      collection2.AddRange(collection1);
      collection2.Count.Should().Be(3);
    }

    [Test]
    public void SortPeopleWithSpecifiedComparerSortsCorrectly()
    {
      var guests = new Guests();
            guests.Add(new Guest { Guest_first_name = "John", Guest_last_name = "Doe" });
            guests.Add(new Guest { Guest_first_name = "Imar", Guest_last_name = "Spaanjaars" });
            guests.Add(new Guest { Guest_first_name = "Jane", Guest_last_name = "Doe" });

      guests.Sort(new GuestComparer());

      guests[0].FullName.Should().Be("Imar Spaanjaars");
      guests[1].FullName.Should().Be("Jane Doe");
      guests[2].FullName.Should().Be("John Doe");
    }

    [Test]
    public void SortIntsSorts()
    {
      var ints = new IntCollection { 3, 2, 1 };
      ints.Sort();
      ints[0].Should().Be(1);
      ints[1].Should().Be(2);
      ints[2].Should().Be(3);
    }

    //[TestMethod]
    //public void AddRangeThrowsWhenCollectionIsNull()
    //{
    //  Action act = () =>
    //    {
    //      var collection = new IntCollection();
    //      collection.AddRange(null);
    //    };
    //  act.ShouldThrow<ArgumentNullException>().WithMessage("collection is null", ComparisonMode.Substring);
    //}


  }

  [ExcludeFromCodeCoverage]
  internal class IntCollection : CollectionBase<int>
  {
    public IntCollection()
    { }

    public IntCollection(IList<int> initialList)
      : base(initialList)
    { }

    public IntCollection(CollectionBase<int> initialList)
      : base(initialList)
    { }
  }

  [ExcludeFromCodeCoverage]
  public class GuestComparer : IComparer<Guest>
  {
    public int Compare(Guest x, Guest y)
    {
      return x.FullName.CompareTo(y.FullName);
    }
  }

}
