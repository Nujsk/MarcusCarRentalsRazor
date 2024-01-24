using MarcusCarRentals.Data;
using MarcusCarRentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcusCarRentals.Pages.UserOrders
{
    public class DisplayOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DisplayOrdersModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<OrderViewModel> Orders { get; private set; }

        public void OnGet()
        {
            string userEmail = "user@example.com"; // You need to replace this with the actual user email or get it from somewhere else

            Orders = DisplayOrders(userEmail);
        }

        private IEnumerable<OrderViewModel> DisplayOrders(string userEmail)
        {
            var orders = _applicationDbContext.Orders
                .Include(o => o.Car)
                .Where(o => o.User.Email == userEmail)
                .ToList();

            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                StartDate = o.StartDate,
                EndDate = o.EndDate,
                CarBrand = o.Car.Brand,
                CarModel = o.Car.Model
            });

            return orderViewModels;
        }
    }
}
