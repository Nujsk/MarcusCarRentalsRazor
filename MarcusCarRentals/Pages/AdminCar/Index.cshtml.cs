using Microsoft.AspNetCore.Mvc.RazorPages;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminCar
{
    public class IndexModel : PageModel
    {
        private readonly ICar _carRep;

        public IndexModel(ICar carRep)
        {
           _carRep = carRep;
        }

        public IEnumerable<Car> Cars { get;set; } = default!;

        public void OnGet()
        {
            if (_carRep != null)
            {
                Cars = _carRep.GetAll();
            }
        }
        public string GetImage(string model)
        {
            return _carRep.GetImagePath(model);
        }
    }
}
