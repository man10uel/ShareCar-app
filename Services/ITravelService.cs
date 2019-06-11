using System;
using System.Threading.Tasks;
using AspNetCoreShareCar.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreShareCar.Services
{
    public interface ITravelService
    {

        Task<Travel[]> GetAllTravelsAsync(IdentityUser user, string passengerOrDriver);
        Task<bool> AddTravelAsync(Travel newTravel);
        Task<bool> ToPayTravelAsync(Guid travelId);

    }
}
