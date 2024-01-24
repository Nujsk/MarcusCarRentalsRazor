using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminUser
{
    public class CreateModel : PageModel
    {
        private readonly IUser _userRep;

        public CreateModel(IUser userRep)
        {
            _userRep = userRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || _userRep == null || User == null)
            {
                return Page();
            }

            _userRep.Add(User);

            return RedirectToPage("./Index");
        }
    }
}
