using AutoMapper;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Entities;
using ENB.Mvc.ApartmentRentals.Models;

namespace ENB.Mvc.ApartmentRentals
{
    public class ApartmentRentalProfil : Profile
    {
        public ApartmentRentalProfil()
        {
            #region Guest 
            CreateMap<Guest, DisplayGuest>();

            CreateMap<CreateAndEditGuest, Guest>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Guest, CreateAndEditGuest>();
            #endregion

            #region ApartmentBuilding 
            CreateMap<Apartment_Building, DisplayApartmentBuilding>();

            CreateMap<CreateAndEditApartmentBuilding, Apartment_Building>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Apartment_Building, CreateAndEditApartmentBuilding>();
            #endregion

            #region Apartment
            CreateMap<Apartment, DisplayApartment>()
             .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId));
             

            CreateMap<CreateAndEditApartment, Apartment>()              
              .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
               .ForMember(d => d.Apartment_Building, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region ApartmentFacility
            CreateMap<Apartment_facility, DisplayApartmentFacility>()
             .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId))
             .ForMember(d => d.ApartmentId, t => t.MapFrom(y => y.ApartmentId))
             .ForMember(d => d.Apartment_Building, t => t.Ignore())
             .ForMember(d => d.Apartment, t => t.Ignore());


            CreateMap<CreateAndEditApartmentFacility, Apartment_facility>()
              .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId))
               .ForMember(d => d.ApartmentId, t => t.MapFrom(y => y.ApartmentId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.Apartment_Building, t => t.Ignore())
              .ForMember(d => d.Apartment, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region ApartmentBooking
            CreateMap<Apartment_booking, DisplayApartmentBooking>()
             .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId))
             .ForMember(d => d.ApartmentId, t => t.MapFrom(y => y.ApartmentId));
             


            CreateMap<CreateAndEditApartmentBooking, Apartment_booking>()
              .ForMember(d => d.Apartment_BuildingId, t => t.MapFrom(y => y.Apartment_BuildingId))
               .ForMember(d => d.ApartmentId, t => t.MapFrom(y => y.ApartmentId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.Apartment_Building, t => t.Ignore())
              .ForMember(d => d.Apartment, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ReverseMap();

            #endregion

            #region GuestAddress         

             CreateMap<GuestAddress, EditGuestAddress>()
            .ForMember(d => d.GuestId, t => t.Ignore());

            CreateMap<EditGuestAddress, GuestAddress>()
            // .ConstructUsing(s=> new GuestAddress(s.Number_street,s.City,s.Zipcode,s.State_province_county,s.Country))
             .ForMember(d => d.Guest, t => t.Ignore())
              .ForMember(d => d.IsNull, t => t.Ignore())
             .ForMember(d => d.DateCreated, t => t.Ignore())
             .ForMember(d => d.DateModified, t => t.Ignore());
             

            #endregion
        }

    }
}
