using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieBasedWebApp.Pages.Account {
    public class LoginModel : PageModel {
        public void OnGet() {
            
        }

        public void OnPost(string email, string password) {

            if (!string.Equals(email, "awesome@email.com") || !string.Equals(password, "SuperStrongPassword1234")) {
                //Hardcoded user verification, here use any logic you want, go to a database, consume a web service
                //Or leave it hardcoded, Idk :)
                return;
            }
            
            //Test different Roles: Admin, MortalUser, Maintainer
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, email),
                new Claim("FullName", "Awesome User"),
                new Claim(ClaimTypes.Role, "MortalUser,Maintainer")//This user has 2 roles but not Admin role
                //new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {
                // Refreshing the authentication session should be allowed.
                AllowRefresh = true,

                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120),

                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.
                IsPersistent = true

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            RedirectToPage("/");
        }
        
    }
}