using AutoMapper;
using ENB.ApartmentRentals.Entities.Collections;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using ENB.Mvc.ApartmentRentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class ApartmentFacilityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IAsyncApartBuildingRepository _asyncApartBuildingRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ApartmentFacilityController> _logger;
        private readonly IMapper _imapper;


        public ApartmentFacilityController(IAsyncApartBuildingRepository asyncApartBuildingRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, ILogger<ApartmentFacilityController> logger, IMapper imapper)
        {
            _asyncApartBuildingRepository = asyncApartBuildingRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
            
        }

        public async Task<IActionResult> List(int Apartment_BuildingId,int ApartmentId)
        {
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.AparId = ApartmentId;
            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId,ap=>ap.Apartments);
            var apart = aprtbld.Apartments.Single(x => x.Id == ApartmentId);

            ViewBag.Message = aprtbld.Building_full_name;
            ViewBag.ArtNumber=apart.Ap_number;

            return View();
        }


        public async Task<IActionResult> GetFacilities(int apartmentbuildingId, int apartmentId)
        {

            var aprtbld = await _asyncApartBuildingRepository.FindById(apartmentbuildingId, x => x.Apartment_Facilities);
            var aprtfc= aprtbld.Apartment_Facilities.Where(x=>x.ApartmentId==apartmentId);
            
          //  var fac = aprt.Apartment_Facilities;
            ViewBag.Message = aprtbld.Building_full_name;

            var Mpdata = new List<DisplayApartmentFacility>();

            _imapper.Map(aprtfc, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int Apartment_BuildingId, int ApartmentId)
        {
            ViewBag.Idapbld = Apartment_BuildingId;
            ViewBag.AparId = ApartmentId;

            var apbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
           

            ViewBag.Message = apbld.Building_full_name;
          
            return View();
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditApartmentFacility createAndEditApartmentFacility, int Apartment_BuildingId, int ApartmentId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var Apartdb = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x=>x.Apartments);

                        var aprt = Apartdb.Apartments.Single(x => x.Id == ApartmentId);

                        Apartment_facility apartment_Facility = new Apartment_facility();

                      
                        _imapper.Map(createAndEditApartmentFacility, apartment_Facility);

                        aprt.Apartment_Facilities.Add(apartment_Facility);
                      

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

            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x=>x.Apartment_Facilities);
            var aprtfc= aprtbld.Apartment_Facilities.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y=>y.Id==id);
            ViewBag.Message = aprtbld.Building_full_name;
            ViewBag.aprtbldId = Apartment_BuildingId;
            ViewBag.Id = id;
            ViewBag.apartId = ApartmentId;
           

            if (aprtbld == null)
            {
                return NotFound();
            }

            CreateAndEditApartmentFacility data = new CreateAndEditApartmentFacility();



            _imapper.Map(aprtfc, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditApartmentFacility createAndEditApartmentFacility, int Apartment_BuildingId,
                                                 int ApartmentId)
        {

            ViewBag.aprtbldId = Apartment_BuildingId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Facilities);
                        var aprtfc = aprtbld.Apartment_Facilities.Where(x => x.ApartmentId == ApartmentId)
                                   .Single(y => y.Id == createAndEditApartmentFacility.Id);

                        //var bldaprt = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartments);
                        //var apart = await Task.FromResult(bldaprt.Apartments.Single(x => x.Id == createAndEditApartment.Id));

                        _imapper.Map(createAndEditApartmentFacility, aprtfc);

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

        public async Task<IActionResult> Details(int Apartment_BuildingId,int ApartmentId, int id)
        {

            var aprtbl = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
            ViewBag.Message = aprtbl.Building_full_name;
            ViewBag.aprtbldId = Apartment_BuildingId;
            ViewBag.Id = id;
            ViewBag.apartId = ApartmentId;

            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Facilities);
            var aprtfc = aprtbld.Apartment_Facilities.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y => y.Id == id);


            if (aprtfc == null)
            {
                return NotFound();
            }
            var myapartfc = new DisplayApartmentFacility();

            var sglaprt = _imapper.Map(aprtfc, myapartfc);

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



            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Facilities);
            var aprtfc = aprtbld.Apartment_Facilities.Where(x => x.ApartmentId == ApartmentId)
                       .Single(y => y.Id == id);


            if (aprtfc == null)
            {
                return NotFound();
            }
            var myapartfc = new DisplayApartmentFacility();

            var sglaprt = _imapper.Map(aprtfc, myapartfc);

            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglaprt);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayApartmentFacility displayApartmentFacility, int Apartment_BuildingId, int ApartmentId)
        {
            // ViewBag.Case_Id = caseid;
            using (_asyncUnitOfWorkFactory.Create())
            {
                var bldaprt = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartment_Facilities);
                var aprtfc = bldaprt.Apartment_Facilities.Where(x => x.ApartmentId == displayApartmentFacility.Id)
                    .Single(y=>y.Id==displayApartmentFacility.Id);

                bldaprt.Apartment_Facilities.Remove(aprtfc);

                // _notifyService.Error("Event related to Lawyer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { Apartment_BuildingId, ApartmentId });
        }
    }
}
