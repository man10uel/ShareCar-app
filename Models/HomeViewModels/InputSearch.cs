using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreShareCar.Models.HomeViewModels
{
    public class InputSearch
    {
        [Required]
        [Display(Name = "Departure city")]
        public string DepartureCity { get; set; }

        [Required]
        [Display(Name = "Arrival city")]
        public string ArrivalCity { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
