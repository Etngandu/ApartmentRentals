using AutoMapper;
using ENB.ApartmentRetals.Entities;
using ENB.ApartmentRentals.Mvc.Models;

namespace ENB.ApartmentRentals.Mvc
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



        }

    }
}
