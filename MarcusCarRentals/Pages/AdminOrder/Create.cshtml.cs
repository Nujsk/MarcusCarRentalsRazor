using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminOrder
{
    public class CreateModel : PageModel
    {
        private readonly IOrder _orderRep;

        public CreateModel(IOrder orderRep)
        {
            _orderRep = orderRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _orderRep == null || Order == null)
          {
                return Page();
          }

            _orderRep.Add(Order);

            return RedirectToPage("./Index");
        }
    }
}
