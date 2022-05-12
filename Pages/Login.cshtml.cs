using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalWebProject.Models;

namespace CarRentalWebProject.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        //private string Id { get; set; }

        [BindProperty]
        public Login Model { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    var isAdmin = await userManager.FindByEmailAsync(Model.Email);

                    if (isAdmin.Email == "admin@gmail.com")
                    {
                        //IdentityUser user = await userManager.FindByNameAsync(Model.Email);
                        //var claim = new Claim("Admin", "true");
                        //var userResult = await userManager.AddClaimAsync(user, claim);
                    }

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, $"{Model.Email}"),
                        new Claim(ClaimTypes.Email, $"{Model.Email}"),
                        new Claim("Admin", "true"),
                    };

                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = Model.RememberMe
                    };

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);

                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or Password incorrect.");
            }

            return Page();
        }
    }
}
