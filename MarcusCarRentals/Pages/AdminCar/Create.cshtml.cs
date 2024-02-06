using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminCar
{
    public class CreateModel : PageModel
    {
        private readonly ICar _carRep;
        public CreateModel(ICar carRep)
        {
            _carRep = carRep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Car Car { get; set; } = default!;
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid || _carRep == null || Car == null)
            {
                return Page();
            }
            _carRep.Add(Car);
            return RedirectToPage("./Index");
        }
    }
}
