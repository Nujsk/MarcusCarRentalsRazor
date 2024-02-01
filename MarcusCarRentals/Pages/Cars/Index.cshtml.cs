using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.Cars
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
