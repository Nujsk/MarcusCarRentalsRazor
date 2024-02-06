using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminOrder
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder _orderRep;
        private readonly ICar _carRep;

        public DeleteModel(IOrder orderRep, ICar carRep)
        {
            _orderRep = orderRep;
            _carRep = carRep;
        }

        [BindProperty]
      public Order Order { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null || _orderRep == null)
            {
                return NotFound();
            }

            var order = _orderRep.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null || _orderRep == null)
            {
                return NotFound();
            }
            var order = _orderRep.GetById(id);

            if (order != null)
            {
                Order = order;
                _orderRep.Delete(Order);
                Order.Car.IsAvailable = true;
                _carRep.Update(Order.Car);
            }

            return RedirectToPage("./Index");
        }
    }
}
