using System;
using Microsoft.EntityFrameworkCore;
using AspNetCoreShareCar.Models;
using System.Threading.Tasks;
using AspNetCoreShareCar.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;


namespace AspNetCoreShareCar.Services
{
    public class TravelService : ITravelService
    {

        private readonly ApplicationDbContext _context;

        public TravelService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Travel[]> GetAllTravelsAsync(ApplicationUser user, string passengerOrDriver)
        {
            Travel[] travels = null;

            switch (passengerOrDriver)
            {
                case "Driver":
                    travels = await _context.Travels
                        .Where(t => t.DriverId == user.Id && t.Paid == false)
                        .ToArrayAsync();

                    break;
                case "Passenger":
                    travels = await _context.Travels
                        .Where(t => t.PassengerId == user.Id && t.Paid == false)
                        .ToArrayAsync();

                    break;
                default:
                    travels = await _context.Travels
                        .Where(t => t.PassengerId == user.Id && t.Paid == false)
                        .ToArrayAsync();
                    break;
            }


            return travels;

        }

        public async Task<bool> AddTravelAsync(Travel newTravel)
        {
            newTravel.Id = new Guid();
            newTravel.Paid = false;

            _context.Travels.Add(newTravel);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;

        }

        public async Task<bool> ToPayTravelAsync(Guid travelId)
        {

            var travel = await _context.Travels
                .Where(t => t.Id == travelId)
                .SingleOrDefaultAsync();

            if (travel == null) return false;

            travel.Paid = true;

            var result = await _context.SaveChangesAsync();

            return result == 1;
                       
        }
    }
}
