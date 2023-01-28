using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using Microsoft.Extensions.Logging;
using ENB.Mvc.ApartmentRentals.Models;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.EF;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class GuestController : Controller
    {
        private readonly IAsyncGuestRepository _asyncGuestRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<GuestController> _logger;
        private readonly IMapper _imapper;
       


        //  private readonly INotyfService _notifyService;


        public GuestController(IAsyncGuestRepository asyncGuestRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
             ILogger<GuestController> logger, IMapper imapper)
        {
            _asyncGuestRepository = asyncGuestRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
            // _asyncUnitOfWork = asyncUnitOfWork; 


        }
        public IActionResult Index()
        {
            return View();
        }

       
        public async Task<IActionResult> GetGuestData()
        {
            IQueryable<Guest> allGuest = _asyncGuestRepository.FindAll();

            var Mpdata = _imapper.Map<List<DisplayGuest>>(allGuest).ToList();
            await  Task.FromResult(Mpdata);
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
        public async Task<IActionResult> Create(CreateAndEditGuest createAndEditGuest)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
              await  using  (await _asyncUnitOfWorkFactory.Create())
                    {
                        Guest dbGuest = new Guest();


                        _imapper.Map(createAndEditGuest, dbGuest);
                      await  _asyncGuestRepository.Add(dbGuest);
                       
                     
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

            _logger.LogError($"Lawyer {id} not found");
            
            Guest dbGuest = await _asyncGuestRepository.FindById(id);

            if (dbGuest == null)
            {
                return NotFound();
            }
            var data = await Task.FromResult(_imapper.Map<CreateAndEditGuest>(dbGuest));

            return View(data);
        }

        // POST: LawyerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditGuest createAndEditGuest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                 await   using (await _asyncUnitOfWorkFactory.Create())
                    {
                       
                        Guest dbGuestToUpdate = await _asyncGuestRepository.FindById(createAndEditGuest.Id);

                        _imapper.Map(createAndEditGuest, dbGuestToUpdate, typeof(CreateAndEditGuest), typeof(Guest));

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

            Guest dbGuest = await _asyncGuestRepository.FindById(id);

            ViewBag.Message = dbGuest.FullName;

            _logger.LogInformation($"Details of Guest: {ViewBag.Message}");

            if (dbGuest == null)
            {
                return NotFound();
            }

            var data = _imapper.Map<DisplayGuest>(dbGuest);

            return View(data);
        }

        // GET: GuestController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Guest dbGuest = await _asyncGuestRepository.FindById(id);
            ViewBag.Message = dbGuest.FullName;

            if (dbGuest == null)
            {
                return NotFound();
            }
            var data = _imapper.Map<DisplayGuest>(dbGuest);
            return View(data);
        }

        // POST: GuestController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Guest dbGuest = await _asyncGuestRepository.FindById(id);
            using (_asyncUnitOfWorkFactory.Create())
            {
              await  _asyncGuestRepository.Remove(dbGuest);

             //   _notifyService.Error("Lawyer Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }


    }
}
