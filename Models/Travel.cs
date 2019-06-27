using System;
using System.ComponentModel.DataAnnotations;
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
        public double Price { get; set; }

        [Required]
        [Display(Name = "Passenger")]
        public string PassengerId { get; set; }

        [Display(Name = "Driver")]
        public string DriverId { get; set;  }

        public bool Paid { get; set; }

    }
}
