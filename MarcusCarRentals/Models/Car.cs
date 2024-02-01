using Humanizer.Localisation.TimeToClockNotation;
using System.ComponentModel.DataAnnotations;

namespace MarcusCarRentals.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; } = "";

        public Car()
        {

        }
    }
}
