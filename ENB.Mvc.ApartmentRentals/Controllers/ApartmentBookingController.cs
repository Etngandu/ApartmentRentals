using AutoMapper;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using ENB.Mvc.ApartmentRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class ApartmentBookingController : Controller
    {

        private readonly IAsyncApartBuildingRepository _asyncApartBuildingRepository;
        private readonly IAsyncGuestRepository _asyncGuestRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ApartmentBookingController> _logger;
        private readonly IMapper _imapper;
        public ApartmentBookingController(IAsyncApartBuildingRepository asyncApartBuildingRepository, IAsyncGuestRepository asyncGuestRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, 
               ILogger<ApartmentBookingController> logger, IMapper imapper)
        {
            _asyncApartBuildingRepository = asyncApartBuildingRepository;
            _asyncGuestRepository=asyncGuestRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List(int Apartment_BuildingId, int ApartmentId)
        {
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.AparId = ApartmentId;
            
            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, bk => bk.Apartments);
            var apartbk = aprtbld.Apartments.Single(x => x.Id == ApartmentId);

            ViewBag.Message = aprtbld.Building_full_name;
            ViewBag.ArtNumber = apartbk.Ap_number;

            return View();
        }


        public async Task<IActionResult> GetListBooking(int apartmentbuildingId, int apartmentId)
        {

            //var aprtbld = await _asyncApartBuildingRepository.FindById(apartmentbuildingId, x => x.Apartment_Bookings);
            //var aprtfc = aprtbld.Apartment_Facilities.Where(x => x.ApartmentId == apartmentId);

            var aprtbkg =  from bk in  _asyncApartBuildingRepository.FindAll().Where(ap=>ap.Id==apartmentbuildingId).SelectMany(apbldg => apbldg.Apartment_Bookings)
                                   .Where(x => x.ApartmentId == apartmentId)
                          join g in  _asyncGuestRepository.FindAll() on bk.GuestId equals g.Id                          
                          join lwy in  _asyncApartBuildingRepository.FindAll() on bk.Apartment_BuildingId equals lwy.Id
                          join ap in _asyncApartBuildingRepository.FindAll().Where(aprt=>aprt.Id==apartmentbuildingId).SelectMany(y=>y.Apartments)
                          on bk.ApartmentId equals ap.Id
                          select new DisplayApartmentBooking
                          {
                              Id = bk.Id,
                              Booking_end_date = bk.Booking_end_date,
                              Booking_start_date = bk.Booking_start_date,
                              Booking_status_code = bk.Booking_status_code,
                              NameBuilding=lwy.Building_short_name,
                              NameGuest=g.FullName,
                              ApartNumber=ap.Ap_number,
                              Other_booking_details = bk.Other_booking_details,
                              
                          };

            
            

            var Mpdata = new List<DisplayApartmentBooking>();

            var lst = await Task.FromResult(aprtbkg);

            _imapper.Map(lst, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int Apartment_BuildingId, int ApartmentId)
        {
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.AparId = ApartmentId;

            var data = new CreateAndEditApartmentBooking()
            {
                Booking_start_date=DateTime.Today,
                Booking_end_date=DateTime.Today,
                ListGuests =_asyncGuestRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.FullName,
                          Value = d.Id.ToString(),
                          Selected = true

                      }).Distinct().ToList() 

            };

            var apbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);


            ViewBag.Message = apbld.Building_full_name;

            return View(data);
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditApartmentBooking createAndEditApartmentBooking, int Apartment_BuildingId, int ApartmentId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var Apartdb = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartments);

                        var aprt = Apartdb.Apartments.Single(x => x.Id == ApartmentId);
                        
                        Apartment_booking apartment_Booking = new Apartment_booking();

                        _imapper.Map(createAndEditApartmentBooking, apartment_Booking);

                        aprt.Apartment_Bookings.Add(apartment_Booking);


                        //   _notifyService.Success("Lawyer event Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { Apartment_BuildingId, ApartmentId });
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                    }
                }
            }
            return View();
        }



        public async Task<IActionResult> Edit(int Apartment_BuildingId, int ApartmentId, int id)
        {

            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Bookings);
            var aprtbk = aprtbld.Apartment_Bookings.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y => y.Id == id);
            ViewBag.Message = aprtbld.Building_full_name;
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.Id = id;
            ViewBag.AparId = ApartmentId;


            if (aprtbld == null)
            {
                return NotFound();
            }

            

            var data = new CreateAndEditApartmentBooking()
            {
                ListGuests = _asyncGuestRepository.FindAll()
                     .Select(d => new SelectListItem
                     {
                         Text = d.FullName,
                         Value = d.Id.ToString(),
                         Selected = true

                     }).Distinct().ToList()


            };

            _imapper.Map(aprtbk, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditApartmentBooking createAndEditApartmentBooking, int Apartment_BuildingId,
                                                 int ApartmentId)
        {

            ViewBag.aprtbldId = Apartment_BuildingId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Bookings);
                        var aprtbk = aprtbld.Apartment_Bookings.Where(x => x.ApartmentId == ApartmentId)
                                   .Single(y => y.Id == createAndEditApartmentBooking.Id);

                        _imapper.Map(createAndEditApartmentBooking, aprtbk);

                        //  _notifyService.Success("Event related to Lawyer updated Successfully");

                        return RedirectToAction(nameof(List), new { Apartment_BuildingId, ApartmentId });
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Details(int Apartment_BuildingId, int ApartmentId, int id)
        {

            var aprtbl = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
            ViewBag.Message = aprtbl.Building_full_name;
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.Id = id;
            ViewBag.AparId = ApartmentId;

            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Bookings);
            var aprtbk = aprtbld.Apartment_Bookings.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y => y.Id == id);


            if (aprtbk == null)
            {
                return NotFound();
            }
            var myapartbk = new DisplayApartmentBooking();

            var sglaprt = _imapper.Map(aprtbk, myapartbk);

            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglaprt);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int Apartment_BuildingId, int ApartmentId, int id)
        {
            var aprtbl = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
            ViewBag.Message = aprtbl.Building_full_name;
            ViewBag.aprtbldId = Apartment_BuildingId;
            ViewBag.Id = id;
            ViewBag.apartId = ApartmentId;



            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Bookings);
            var aprtbk = aprtbld.Apartment_Bookings.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y => y.Id == id);


            if (aprtbk == null)
            {
                return NotFound();
            }
            var myapartbk = new DisplayApartmentBooking();

            var sglaprt = _imapper.Map(aprtbk, myapartbk);

            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglaprt);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayApartmentBooking displayApartmentBooking, 
                int Apartment_BuildingId, int ApartmentId)
        {
            
          await  using (await _asyncUnitOfWorkFactory.Create())
            {
                var bldaprt = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Bookings);
                var aprtbk = bldaprt.Apartment_Bookings.Where(x => x.ApartmentId == ApartmentId)
                    .Single(y=>y.Id==displayApartmentBooking.Id);

                bldaprt.Apartment_Bookings.Remove(aprtbk);

                // _notifyService.Error("Event related to Lawyer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { Apartment_BuildingId, ApartmentId });
        }
    }
}
