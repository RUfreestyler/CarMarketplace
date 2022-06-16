using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.ViewModels;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class ProfileModel : PageModel
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

        public ProfileViewModel User { get; set; }

        readonly IRepository repository;
        readonly IHashComputer hasher;

        public ProfileModel(IRepository repository, IHashComputer hasher)
        {
            this.repository = repository;
            this.hasher = hasher; 
        }

        public void OnGet()
        {
            var owner = repository.GetAllOwners()
                .Where(x => x.ID == int.Parse(HttpContext.User.FindFirst("ID").Value))
                .FirstOrDefault();
            if (owner != null)
            {
                User = new ProfileViewModel()
                {
                    Name = owner.Name,
                    City = owner.City,
                    Phone = owner.PhoneNumber,
                    Email = owner.Email
                };
            }
        }

        public void OnPost()
        {
            var owner = repository.GetAllOwners()
                .Where(x => x.ID == int.Parse(HttpContext.User.FindFirst("ID").Value))
                .FirstOrDefault();
            if(owner != null)
            {
                owner.Name = Name;
                owner.City = City;
                owner.PhoneNumber = Phone;
                owner.Email = Email;
                if (!string.IsNullOrWhiteSpace(Password))
                    owner.PasswordHash = hasher.GetHashCode(Password);

                User = new ProfileViewModel()
                {
                    Name = owner.Name,
                    City = owner.City,
                    Phone = owner.PhoneNumber,
                    Email = owner.Email
                };
            }
            repository.Update(owner);
        }
    }
}
