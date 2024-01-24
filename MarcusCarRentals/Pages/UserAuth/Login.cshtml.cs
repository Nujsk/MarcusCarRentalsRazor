using MarcusCarRentals.Data;
using MarcusCarRentals.Models;
using MarcusCarRentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcusCarRentals.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public string Email { get; set; } = "";
        [BindProperty]
        public string Password { get; set; } = "";
        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (IsValidUser(Email, Password, out var user))
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetInt32("IsAdmin", Convert.ToInt32(user.IsAdmin));
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
            }
            return Page();
        }
        private bool IsValidUser(string username, string password, out User user)
        {
            user = _context.Users.FirstOrDefault(u => u.Email == username);
            return user != null && user.Password == password;
        }
    }
}
