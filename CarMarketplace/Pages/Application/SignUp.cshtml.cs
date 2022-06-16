using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CarMarketplace.Pages.Application
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "¬ведите им€")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите город")]
        public string City { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите номер телефона")]
        public string Phone { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите почту")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите пароль")]
        public string Password { get; set; }

        private readonly IRepository repository;
        private readonly IHashComputer hasher;

        public SignUpModel(IRepository repository, IHashComputer hasher)
        {
            this.repository = repository;
            this.hasher = hasher;
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var newUser = new Owner()
            {
                Name = Name,
                City = City,
                PhoneNumber = Phone,
                Email = Email,
                PasswordHash = hasher.GetHashCode(Password)
            };
            repository.Add(newUser);

            var claims = new List<Claim>()
            {
                new Claim("ID", repository.GetAllOwners().Where(x => x.Email == newUser.Email).FirstOrDefault().ID.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return Redirect("../Index");
        }
    }
}
