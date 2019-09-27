using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreShareCar.Models
{
    public class Booking
    {

        public Guid Id { get; set; }

        // Relations
        public Travel Travel { get; set; }
        public ApplicationUser Passenger { get; set; }

    }
}
