using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Models;
using CarMarketplace.Services;

namespace CarMarketplace.Pages.Application
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public string? Login { get; set; }

        [BindProperty]
        public string? Password { get; set; }
        public string? UserName { get; set; }

        private IRepository marketplaceRepository;

        public SignInModel(IRepository marketplaceRepository)
        {
            this.marketplaceRepository = marketplaceRepository;
            UserName = "Вход/Регистрация";
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var owner = marketplaceRepository.GetAllOwners()
                .Where(x => x.Email == Login || x.PhoneNumber == Login)
                .FirstOrDefault();

            if(owner != null && owner.PasswordHash == Hasher.GetHashCode(Password))
            {
                UserName = owner.Name;
                return RedirectToPage("/Index", new { UserName });
            }

            return Page();
        }
    }
}
