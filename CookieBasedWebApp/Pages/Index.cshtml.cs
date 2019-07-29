using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieBasedWebApp.Pages {

    [Authorize]
    public class IndexModel : PageModel {
        public string LoggedUserName = "";
        
        public void OnGet() {
            var claimEmail = HttpContext.User.FindFirst(ClaimTypes.Name);
            var claimFullName = HttpContext.User.FindFirst("FullName");
            if (claimEmail != null && claimFullName != null) {
                LoggedUserName = $"{claimEmail.Value} - {claimFullName.Value}";
            }
        }
    }
}