using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.Models;

namespace CarMarketplace.Pages.Application
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public string? City { get; set; }

        [BindProperty]
        public string? Phone { get; set; }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }
        private IRepository marketplaceRepository;

        public SignUpModel(IRepository marketplaceRepository)
        {
            this.marketplaceRepository = marketplaceRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var newOwner = new Owner()
            {
                Name = Name,
                City = City,
                PhoneNumber = Phone,
                Email = Email,
                PasswordHash = Hasher.GetHashCode(Password)
            };
            marketplaceRepository.Add(newOwner);
            return RedirectToPage("/Index");
        }
    }
}
