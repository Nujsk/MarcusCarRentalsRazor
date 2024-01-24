using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcusCarRentals.Pages.UserAuth
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
