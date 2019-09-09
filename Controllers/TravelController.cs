using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreShareCar.Data;
using AspNetCoreShareCar.Services;
using AspNetCoreShareCar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreShareCar.Controllers
{
    [Authorize]
    public class TravelController : Controller
    {

        private readonly ITravelService _travelService;
        private readonly UserManager<ApplicationUser> _userManager;


        public TravelController(ITravelService travelService, 
            UserManager<ApplicationUser> userManager)
        {
            _travelService  = travelService;
            _userManager = userManager;
        }

        // GET: Travel
        public async Task<IActionResult> Index(string passengerOrDriver = "Driver")
        {        

            switch (passengerOrDriver)
            {
                case "Driver":
                    ViewData["CurrentPassengerOrDriver"] = "Passenger";
                    break;
                case "Passenger":
                    ViewData["CurrentPassengerOrDriver"] = "Driver";
                    break;
                default:
                    ViewData["CurrentPassengerOrDriver"] = "Driver";
                    break;
            }
              
            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser == null)
            {
                return Challenge();
            }

            var travels = await _travelService.GetAllTravelsAsync(currentUser, passengerOrDriver);

            return View(new TravelViewModel { Travels = travels});
        }

        // GET: Travel/Create
        [HttpGet]
        public IActionResult Create()
        {        
            return View();
        }

        // POST: Travel/Create
        [HttpPost]
        public async Task<IActionResult> Create(Travel newTravel)
        {        

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }           

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null) return Challenge();

            var travelToSave = new Travel()
            {
                Seats = newTravel.Seats,
                ArrivalCity = newTravel.ArrivalCity,
                DepartureCity = newTravel.DepartureCity,
                DueAt = newTravel.DueAt,
                PassengerId = newTravel.PassengerId,
                Price = newTravel.Price,
                DriverId = currentUser.Id
            };


            var successful = await _travelService.AddTravelAsync(travelToSave);

            if (!successful)
            {
                return BadRequest("Could not add the travel.");
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> ToPay(Guid travelId)
        {

            if(travelId == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var succesful = await _travelService.ToPayTravelAsync(travelId);

            if (!succesful)
                return BadRequest("Could not pay the travel.");

            return RedirectToAction("Index");
        }


    }
}
