using MarcusCarRentals.Data;
using MarcusCarRentals.Models;
using MarcusCarRentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcusCarRentals.Pages.UserOrders
{
    public class DisplayOrdersModel : PageModel
    {
        private readonly IOrder _orderRep;
        public DisplayOrdersModel(IOrder orderRep)
        {
            _orderRep = orderRep;
        }
        public IEnumerable<Order> ActiveOrders { get; private set; }
        public IEnumerable<Order> PastOrders { get; private set; }

        public void OnGet()
        {
            string user = HttpContext.Session.GetString("Email");
            if(ModelState.IsValid) 
            {
                ActiveOrders = _orderRep.GetActiveOrders(user);
                PastOrders = _orderRep.GetPastOrders(user);
            }
            else
            {
                RedirectToPage("/Index");
            }
        }
    }
}
