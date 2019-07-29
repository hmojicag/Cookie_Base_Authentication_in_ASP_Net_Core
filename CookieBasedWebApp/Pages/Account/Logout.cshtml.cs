using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieBasedWebApp.Pages.Account {
    public class LogoutModel : PageModel {
        public void OnGet() {
            
        }

        public void OnPost() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}