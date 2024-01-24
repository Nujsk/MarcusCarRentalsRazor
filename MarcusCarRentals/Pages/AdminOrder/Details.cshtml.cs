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
    public class DetailsModel : PageModel
    {
        private readonly IOrder _orderRep;

        public DetailsModel(IOrder orderRep)
        {
            _orderRep = orderRep;
        }

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
    }
}
