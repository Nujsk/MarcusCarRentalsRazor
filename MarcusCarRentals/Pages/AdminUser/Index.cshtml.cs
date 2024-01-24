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
    public class IndexModel : PageModel
    {
        private readonly IUser _userRep;

        public IndexModel(IUser userRep)
        {
            _userRep = userRep;
        }

        public IEnumerable<User> Users { get;set; } = default!;

        public void OnGet()
        {
            if (_userRep != null)
            {
                Users = _userRep.GetAll();
            }
        }
    }
}
