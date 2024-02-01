using MarcusCarRentals.Data;
using MarcusCarRentals.Models;
using MarcusCarRentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public Car SelectedCar { get; set; }

        [BindProperty]
        public CreateOrderViewModel Model { get; set; }
        public IActionResult OnGet()
        {
            var currentUserId = HttpContext.Session.GetString("Email");
            if(currentUserId != null)
            {
                Model = new CreateOrderViewModel();
                if (int.TryParse(Request.Query["id"], out int id))
                {
                    Model.CarId = id;
                }
                else
                {
                    return RedirectToPage("/Error");
                }
                Model.CarOptions = GetCarOptions();
                return Page();
            }
            return RedirectToPage("/UserAuth/Login");
        }

        private IEnumerable<SelectListItem> GetCarOptions()
        {
            var availableCars = _carRep.GetAll().ToList();

            return availableCars.Select(car => new SelectListItem
            {
                Value = car.CarId.ToString(),
                Text = $"{car.Brand} {car.Model}"
            });
        }


        public IActionResult OnPost()
        {
            int currentUserId = HttpContext.Session.GetInt32("UserId") ?? throw new Exception("User Id Null");

            if (currentUserId != 0)
            {
                try
                {
                    var car = _carRep.GetById(Model.CarId);
                    var user = _userRep.GetById(currentUserId);
                    var order = new Order
                    {
                        Car = car,
                        User = user,
                        StartDate = Model.StartDate,
                        EndDate = Model.EndDate,
                        IsActive = true
                    };

                    _orderRep.Add(order);
                    car.IsAvailable = false;
                    _carRep.Update(car);
                    TempData["SuccessMessage"] = "Order lagd!";
                    return RedirectToPage("/UserOrders/DisplayOrders");
                }
                catch (Exception ex)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/UserAuth/Login");
        }
    }
}

