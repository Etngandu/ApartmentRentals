using AutoMapper;
using ENB.ApartmentRentals.EF;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using ENB.Mvc.ApartmentRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IAsyncApartBuildingRepository _asyncApartBuildingRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ApartmentController> _logger;
        private readonly IMapper _imapper;
       

        public ApartmentController(IAsyncApartBuildingRepository asyncApartBuildingRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, ILogger<ApartmentController> logger, IMapper imapper)
        {
            _asyncApartBuildingRepository = asyncApartBuildingRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
          //  _asyncUnitOfWork = asyncUnitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int Apartment_BuildingId)
        {
            ViewBag.Idapbld = Apartment_BuildingId;
            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);

            ViewBag.Message = aprtbld.Building_full_name;

            return View();
        }

       
        public async Task<IActionResult> GetApartments(int apBldId)
        {           

            var aprtbld = await _asyncApartBuildingRepository.FindById(apBldId, x => x.Apartments);

            ViewBag.Message = aprtbld.Building_full_name;

            var Mpdata = new List<DisplayApartment>();

            _imapper.Map(aprtbld.Apartments, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int Apartment_BuildingId)
        {
            ViewBag.Idapbld= Apartment_BuildingId;

            var apbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);

            ViewBag.Message=apbld.Building_full_name;
           
            return View();
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditApartment createAndEditApartment, int Apartment_BuildingId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                  await  using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var Apartdb = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);

                        Apartment apartment = new Apartment();

                        _imapper.Map(createAndEditApartment, apartment);
                      
                        
                        Apartdb.Apartments.Add(apartment);

                     //   _notifyService.Success("Lawyer event Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { Apartment_BuildingId });
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

       

        public async Task<IActionResult> Edit(int Apartment_BuildingId, int id)
        {

            var aprtbld = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
            ViewBag.Message = aprtbld.Building_full_name;
            ViewBag.aprtbldId = Apartment_BuildingId;
            ViewBag.Id = id;

            var apartmt = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, aptbld => aptbld.Apartments);

            if (apartmt == null)
            {
                return NotFound();
            }

            CreateAndEditApartment data= new CreateAndEditApartment ();

            

            _imapper.Map(aprtbld.Apartments.Single(x => x.Id == id), data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditApartment createAndEditApartment, int Apartment_BuildingId)
        {

            ViewBag.aprtbldId = Apartment_BuildingId;
            if (ModelState.IsValid)
            {
                try
                {
                  await  using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var bldaprt = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartments);
                        var apart = await Task.FromResult(bldaprt.Apartments.Single(x => x.Id == createAndEditApartment.Id));

                        _imapper.Map(createAndEditApartment, apart);

                        //  _notifyService.Success("Event related to Lawyer updated Successfully");

                        return RedirectToAction(nameof(List), new { Apartment_BuildingId });
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

        public async Task<IActionResult> Details(int apbldid, int id)
        {

            var aprtbl = await _asyncApartBuildingRepository.FindById(apbldid);
            ViewBag.Message = aprtbl.Building_full_name;
            ViewBag.aprtbldId = apbldid;
            ViewBag.Id = id;

           // var bldaprt = await _asyncApartBuildingRepository.FindById(apbldid, apbl => apbl.Apartments);

            var bldaprt =  from a in  _asyncApartBuildingRepository.FindAll().Where(apb=>apb.Id==apbldid).SelectMany(aprt => aprt.Apartments)
                          join apb in _asyncApartBuildingRepository.FindAll() on a.Apartment_BuildingId equals apb.Id                        
                          select new DisplayApartment
                          {
                              Id = a.Id,
                              Apartment_BuildingId = apb.Id,
                              Ap_number=a.Ap_number,
                              Ap_type=a.Ap_type,
                              Bathroom_count=a.Bathroom_count,
                              Bedroom_count=a.Bathroom_count,
                              NameBuilding=apb.Building_full_name,
                              Room_count=a.Room_count,
                              Other_apartement_details=a.Other_apartement_details
                              
                          };


            if (bldaprt == null)
            {
                return NotFound();
            }
             var myapart = new DisplayApartment();

             var sglaprt = _imapper.Map(bldaprt.Single(x => x.Id == id), myapart);

           // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglaprt);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int Apartment_BuildingId, int id)
        {
            var aprtbl = await _asyncApartBuildingRepository.FindById(Apartment_BuildingId);
            ViewBag.Message = aprtbl.Building_full_name;
            ViewBag.aprtbldId = Apartment_BuildingId;
            ViewBag.Id = id;

           

            var bldaprt = from a in _asyncApartBuildingRepository.FindAll().Where(apb => apb.Id == Apartment_BuildingId).SelectMany(aprt => aprt.Apartments)
                          join apb in _asyncApartBuildingRepository.FindAll() on a.Apartment_BuildingId equals apb.Id
                          select new DisplayApartment
                          {
                              Id = a.Id,
                              Apartment_BuildingId = apb.Id,
                              Ap_number = a.Ap_number,
                              Ap_type = a.Ap_type,
                              Bathroom_count = a.Bathroom_count,
                              Bedroom_count = a.Bathroom_count,
                              NameBuilding = apb.Building_full_name,
                              Room_count = a.Room_count,
                              Other_apartement_details = a.Other_apartement_details

                          };


            if (bldaprt == null)
            {
                return NotFound();
            }
            var myapart = new DisplayApartment();

            var sglaprt = _imapper.Map(bldaprt.Single(x => x.Id == id), myapart);

            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglaprt);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayApartment displayApartment, int Apartment_BuildingId)
        {
            // ViewBag.Case_Id = caseid;
          await  using ( await _asyncUnitOfWorkFactory.Create())
            {
                var bldaprt =await _asyncApartBuildingRepository.FindById(Apartment_BuildingId, x => x.Apartments);
                var aprt = bldaprt.Apartments.Single(x => x.Id == displayApartment.Id);

                bldaprt.Apartments.Remove(aprt);

               // _notifyService.Error("Event related to Lawyer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { Apartment_BuildingId });
        }

    }
}
