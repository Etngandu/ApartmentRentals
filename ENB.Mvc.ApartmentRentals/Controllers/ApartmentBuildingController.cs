using AutoMapper;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using ENB.Mvc.ApartmentRentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class ApartmentBuildingController: Controller
    {
        private readonly IAsyncApartBuildingRepository _asyncApartBuildingRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ApartmentBuildingController> _logger;
        private readonly IMapper _imapper;
       // private readonly IAsyncUnitOfWork _asyncUnitOfWork;


        //  private readonly INotyfService _notifyService;


        public ApartmentBuildingController(IAsyncApartBuildingRepository asyncApartBuildingRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
             ILogger<ApartmentBuildingController> logger, IMapper imapper)
        {
            _asyncApartBuildingRepository = asyncApartBuildingRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
         //   _asyncUnitOfWork = asyncUnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetApartBuildingData()
        {
            IQueryable<Apartment_Building> allApartBld = _asyncApartBuildingRepository.FindAll();

            var Mpdata = _imapper.Map<List<DisplayApartmentBuilding>>(allApartBld).ToList();
            await Task.FromResult(Mpdata);
            return Json(new { data = Mpdata });
        }

        // GET: GuestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditApartmentBuilding createAndEditApartmentBuilding)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                 await   using (await _asyncUnitOfWorkFactory.Create())
                    {
                      
                        Apartment_Building dbAprtBld = new Apartment_Building();

                        _imapper.Map(createAndEditApartmentBuilding, dbAprtBld);
                        await _asyncApartBuildingRepository.Add(dbAprtBld);


                        return RedirectToAction("Index");
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

        // GET: LawyerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            _logger.LogError($"ApartBld {id} not found");

            Apartment_Building dbApartBld = await _asyncApartBuildingRepository.FindById(id);

            if (dbApartBld == null)
            {
                return NotFound();
            }
            var data = await Task.FromResult(_imapper.Map<CreateAndEditApartmentBuilding>(dbApartBld));

            return View(data);
        }

        // POST: LawyerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditApartmentBuilding createAndEditApartmentBuilding)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  await  using (await _asyncUnitOfWorkFactory.Create())
                    {

                        Apartment_Building dbApartBldToUpdate = await _asyncApartBuildingRepository.FindById(createAndEditApartmentBuilding.Id);

                        _imapper.Map(createAndEditApartmentBuilding, dbApartBldToUpdate, typeof(CreateAndEditGuest), typeof(Guest));

                        //   _notifyService.Success("Lawyer Update  Successfully! ");

                        return RedirectToAction(nameof(Index));
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


        // GET: GuestController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Id = id;

            _logger.LogError($"Id :{id} of lawyer not found");

            Apartment_Building dbApartBld = await _asyncApartBuildingRepository.FindById(id);

            ViewBag.Message = dbApartBld.Building_full_name;

            _logger.LogInformation($"Details of Guest: {ViewBag.Message}");

            if (dbApartBld == null)
            {
                return NotFound();
            }

            var data = _imapper.Map<DisplayApartmentBuilding>(dbApartBld);

            return View(data);
        }

        // GET: GuestController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Apartment_Building dbApartBld = await _asyncApartBuildingRepository.FindById(id);
            ViewBag.Message = dbApartBld.Building_full_name;

            if (dbApartBld == null)
            {
                return NotFound();
            }
            var data = _imapper.Map<DisplayApartmentBuilding>(dbApartBld);
            return View(data);
        }

        // POST: GuestController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Apartment_Building dbApartBld = await _asyncApartBuildingRepository.FindById(id);
           await using (await _asyncUnitOfWorkFactory.Create())
            {
                await _asyncApartBuildingRepository.Remove(dbApartBld);

                //   _notifyService.Error("Lawyer Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }

    }
}
