using MarcusCarRentals.Data;
using MarcusCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcusCarRentals.Pages.UserOrders
{
    public class CreateNewUserOrderModel : PageModel
    {
        private readonly IOrder _orderRep;
        private readonly ICar _carRep;
        private readonly IUser _userRep;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateNewUserOrderModel(IOrder orderRep, ICar carRep, IUser userRep, IHttpContextAccessor httpContextAccessor)
        {
            _orderRep = orderRep;
            _carRep = carRep;
            _userRep = userRep;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            int currentUserId = HttpContext.Session.GetInt32("UserId") ?? throw new Exception("User Id Null");

            if (currentUserId != 0)
            {
                try
                {
                    var carId = Convert.ToInt32(Request.Form["CarId"]);
                    var startDate = Convert.ToDateTime(Request.Form["StartDate"]);
                    var endDate = Convert.ToDateTime(Request.Form["EndDate"]);

                    var car = _carRep.GetById(carId);
                    var user = _userRep.GetById(currentUserId);

                    var order = new Order
                    {
                        Car = car,
                        User = user,
                        StartDate = startDate,
                        EndDate = endDate,
                        IsActive = true
                    };

                    _orderRep.Add(order);
                    car.IsAvailable = false;
                    _carRep.Update(car);

                    TempData["SuccessMessage"] = "Order successfully placed!";
                    return RedirectToPage("/UserOrders/DisplayOrders");
                }
                catch (Exception ex)
                {
                    return RedirectToPage("Error");
                }
            }
            return RedirectToPage("LoginAuth", "Login");
        }
    }
}

