using MarcusCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarcusCarRentals.Data;

namespace MarcusCarRentals.Pages.UserOrders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder _orderRep;
        public DeleteModel(IOrder orderRep)
        {
            _orderRep = orderRep;
        }
        [BindProperty]
        public Order Order { get; set; }

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
            }

            return RedirectToPage("/UserOrders/DisplayOrders");
        }
    }
}
