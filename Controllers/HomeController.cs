using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreShareCar.Models;
using AspNetCoreShareCar.Services;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreShareCar.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITravelService _travelService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ITravelService travelService, UserManager<ApplicationUser> userManager)
        {
            _travelService = travelService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> SearchTravels(Models.HomeViewModels.InputSearch inputSearch)
        {
            var travels = await _travelService.SearchTravels(inputSearch.DepartureCity, inputSearch.ArrivalCity, inputSearch.Date);
            var currentUser = await _userManager.GetUserAsync(User);

            foreach (var travel in travels)
            {
                var driver = await _userManager.FindByIdAsync(travel.DriverId);
                travel.Driver = driver;
                foreach (var booking in travel.Bookings)
                {
                    if (currentUser.Id == booking.Passenger.Id)
                        travels = travels.Where(tr => tr.Id != travel.Id).ToArray();
                }
            }

            return View(travels);
        }
    }
}
