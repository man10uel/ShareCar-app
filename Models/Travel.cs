using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace AspNetCoreShareCar.Models
{
    public class Travel
    {

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Number of seats")]
        [Range(1, 10)]
        public int Seats { get; set; }

        [Required]
        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; }

        [Required]
        [Display(Name = "Arrival City")]
        public string ArrivalCity { get; set;  }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DueAt { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }        

        [Display(Name = "Driver")]
        public string DriverId { get; set;  }

        public bool Paid { get; set; }

        // Relations
        public ApplicationUser Driver { get; set; }
        public IList<Booking> Bookings { get; set; }

    }
}
