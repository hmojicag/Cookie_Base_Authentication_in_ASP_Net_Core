using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieBasedWebApp.Pages {
    [Authorize(Roles = "Admin")]
    public class AdminOnlyModel : PageModel {
        public void OnGet() {
            
        }
    }
}