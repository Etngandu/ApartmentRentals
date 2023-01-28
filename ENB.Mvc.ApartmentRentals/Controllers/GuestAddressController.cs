using AutoMapper;
using ENB.ApartmentRentals.EF.Repositories;
using ENB.ApartmentRentals.Entities;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRetals.Infrastructure;
using ENB.Mvc.ApartmentRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ENB.Mvc.ApartmentRentals.Controllers
{
    public class GuestAddressController : Controller
    {
        private readonly IAsyncGuestRepository _asyncGuestRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<GuestAddressController> _logger;
        private readonly IMapper _imapper;
       

        public GuestAddressController(IAsyncGuestRepository asyncGuestRepository, IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
        ILogger<GuestAddressController> logger, IMapper imapper)
        {   
           _asyncGuestRepository=asyncGuestRepository
                ?? throw new ArgumentNullException(nameof(asyncGuestRepository));   
            _asyncUnitOfWorkFactory=asyncUnitOfWorkFactory;
               _logger=logger;  
            _imapper=imapper;           
        }
        public IActionResult Index()
        {
            return View();
        }

        public  async Task<IActionResult> ProcessAddress(int guestId)
        {
            var dbGuestAdr = await _asyncGuestRepository.FindById(guestId,x=>x.GuestAddress);

            var SglAdr = dbGuestAdr.GuestAddress.Id;

            ActionResult result;
            if (SglAdr == 0)
            {
                result = RedirectToAction("Create", new {guestId});
            }
            else
            {
                result = RedirectToAction("Edit", new {guestId});
            }

            return await Task.FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int guestId)
        {
            ViewBag.Idguest = guestId;

            var guest = await _asyncGuestRepository.FindById(guestId);

            ViewBag.Message = guest.FullName;

            return View();
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditGuestAddress editGuestAddress, int guestId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var guestdb = await _asyncGuestRepository.FindById(guestId);
                      
                        GuestAddress guestAddress = new GuestAddress();

                        _imapper.Map(editGuestAddress, guestAddress);

                      
                        guestdb.GuestAddress = guestAddress;

                        //   _notifyService.Success("Lawyer event Added  Successfully! ");

                        return RedirectToAction(nameof(Index), "Guest");
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
        public async Task<ActionResult> Edit(int guestId)
        {
            var guest = await _asyncGuestRepository.FindById(guestId, x => x.GuestAddress);
            ViewBag.Message = guest.FullName;
            ViewBag.Idguest = guestId;
            ViewBag.Id = guest.GuestAddress.Id;

            if (guest == null)
            {
                return NotFound();
            }
            var data = new EditGuestAddress();
            _imapper.Map(guest.GuestAddress, data);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditGuestAddress editGuestAddress)
        {
            if (ModelState.IsValid)
            {
                try
                {
               await  using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var guest = await _asyncGuestRepository.FindById(editGuestAddress.GuestId, x=>x.GuestAddress);
                        var adrgst =  guest.GuestAddress;

                        _imapper.Map(editGuestAddress, adrgst);
                        
                        return RedirectToAction(nameof(Index),"Guest");
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
    }
}
