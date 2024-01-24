using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminOrder
{
    public class EditModel : PageModel
    {
        private readonly IOrder _orderRep;

        public EditModel(IOrder orderRep)
        {
            _orderRep = orderRep;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null || _orderRep == null)
            {
                return NotFound();
            }

            var order =  _orderRep.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _orderRep.Update(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
          return Convert.ToBoolean(_orderRep.GetById(id));
        }
    }
}
