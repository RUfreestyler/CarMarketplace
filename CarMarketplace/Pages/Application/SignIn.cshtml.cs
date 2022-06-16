using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CarMarketplace.Pages.Application
{
    public class SignInModel : PageModel
    {
        private readonly IRepository repository;
        private readonly IHashComputer hasher;

        public SignInModel(IRepository marketplaceRepository, IHashComputer hasher)
        {
            this.repository = marketplaceRepository;
            this.hasher = hasher;
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(!repository.GetAllOwners().Where(x => x.Email == HttpContext.Request.Form["login"] ||
                x.PhoneNumber == HttpContext.Request.Form["login"]).Any())
            {
                return Redirect("SignUp");
            }

            var user = repository.GetAllOwners()
                .Where(x => (x.Email == HttpContext.Request.Form["login"] || 
                x.PhoneNumber == HttpContext.Request.Form["login"]) &&
                x.PasswordHash == hasher.GetHashCode(HttpContext.Request.Form["password"]))
                .FirstOrDefault();

            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>() { new Claim("ID", user.ID.ToString()) };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));


            return Redirect(returnUrl ?? "/");
        }
    }
}
