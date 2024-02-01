using MarcusCarRentals.Data;
using MarcusCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MarcusCarRentals.Pages.UserOrders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder _orderRep;
        private readonly ICar _carRep;
        private readonly IUser _userRep;
        public DeleteModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            _orderRep = orderRep;
            _carRep = carRep;
            _userRep = userRep;
        }
        [BindProperty]
        public Order Order { get; set; }
        public IActionResult OnGet(int id)
        {
            Order = _orderRep.GetById(id);
            if (Order == null || _orderRep == null)
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
            try
            {
                Order.IsActive = false;
                _orderRep.Update(Order);
                Order.Car.IsAvailable = true;
                _carRep.Update(Order.Car);

                TempData["OrderDeleted"] = "Order borttagen!";
                return RedirectToPage("/UserOrders/DisplayOrders");
            }
            catch (Exception)
            {
                return RedirectToPage("Error");
            }
        }
    }
}