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
        private readonly ICar _carRep;
        private readonly IUser _userRep;

        public EditModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            _orderRep = orderRep;
            _carRep = carRep;
            _userRep = userRep;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            Order = _orderRep.GetById(id);

            if (Order == null)
            {
                return NotFound();
            }
            Order.Car = _carRep.GetById(Order.CarId);
            Order.User = _userRep.GetById(Order.UserId);
            return Page();
        }

        public IActionResult OnPost()
        {
            Order.Car = _carRep.GetById(Order.CarId);
            Order.User = _userRep.GetById(Order.UserId);

            if (Order.Car == null || Order.User == null)
            {
                return NotFound();
            }
            try
            {
                _orderRep.Update(Order);
                return RedirectToPage("/AdminOrder/Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToPage("/Error");
            }
        }
    }
}
