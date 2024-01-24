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
    public class DetailsModel : PageModel
    {
        private readonly ICar _carRep;

        public DetailsModel(ICar carRep)
        {
            _carRep = carRep;
        }

      public Car Car { get; set; } = default!; 

        public IActionResult OnGet(int id)
        {
            if (id == null || _carRep == null)
            {
                return NotFound();
            }

            var car = _carRep.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
