using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MarcusCarRentals.ViewModels
{
    public class CreateOrderViewModel
    {
        public int CarId { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public IEnumerable<SelectListItem> CarOptions { get; set; }

        public CreateOrderViewModel(int carId)
        {
            CarId = carId;
        }
        public CreateOrderViewModel()
        {
            
        }
    }
}
