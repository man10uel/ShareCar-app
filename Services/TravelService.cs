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
                        .Where(t => t.DriverId != user.Id && t.Paid == false)
                        .ToArrayAsync();

                    break;
                default:
                    travels = await _context.Travels
                        .Where(t => t.DriverId == user.Id && t.Paid == false)
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

        public async Task<Travel> GetTravelAsync(Guid travelId)
        {
            var travel = await _context.Travels
                .Where(t => t.Id == travelId)
                .SingleOrDefaultAsync();

            return travel;
        }

        public async Task<bool> BookTravel(ApplicationUser currentUser, Travel travel)
        {
            var booking = new Booking()
            {
                Id = new Guid(),
                Passenger = currentUser,
                Travel = travel
            };

            await _context.Bookings.AddAsync(booking);
            var result = await _context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<Travel[]> SearchTravels(string departureCity, string arrivalCity, DateTime date)
        {
            var travels = await _context.Travels
                .Include(travel => travel.Bookings)   
                    .ThenInclude(booking => booking.Passenger)                    
                .Where(travel => travel.DueAt == date && travel.DepartureCity == departureCity && travel.ArrivalCity == arrivalCity)
                .ToArrayAsync();

            return travels;

        }
    }
}
