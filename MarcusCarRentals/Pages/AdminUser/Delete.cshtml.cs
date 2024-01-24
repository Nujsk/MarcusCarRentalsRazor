using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarcusCarRentals.Data;
using MarcusCarRentals.Models;

namespace MarcusCarRentals.Pages.AdminUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUser _userRep;

        public DeleteModel(IUser userRep)
        {
            _userRep = userRep;
        }

        [BindProperty]
      public User User { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null || _userRep == null)
            {
                return NotFound();
            }

            var user = _userRep.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null || _userRep == null)
            {
                return NotFound();
            }
            var user = _userRep.GetById(id);

            if (user != null)
            {
                User = user;
                _userRep.Delete(User);
            }

            return RedirectToPage("./Index");
        }
    }
}
