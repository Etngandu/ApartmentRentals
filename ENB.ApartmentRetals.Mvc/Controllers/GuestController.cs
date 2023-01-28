using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ENB.ApartmentRetals.Entities;
using ENB.ApartmentRetals.Infrastructure;
using Microsoft.Extensions.Logging;
using ENB.ApartmentRentals.Mvc.Models;
using ENB.ApartmentRentals.Entities.Repositories;

namespace ENB.ApartmentRentals.Mvc.Controllers
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
           
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetLawyerData()
        //{
        //    IQueryable<LawyerOffice.Entities.Lawyer> allLawyers = _lawyerRepository.FindAll();

        //    var Mpdata = _imapper.Map<List<DisplayLawyer>>(allLawyers).ToList();
        //    return Json(new { data = Mpdata });
        //}

       
        
    }
}
