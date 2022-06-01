using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Models;
using CarMarketplace.Services;

namespace CarMarketplace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MarketplaceContext? Context { get; set; }

        public string? UserName { get; set; }
        public bool UserIsAuthorized { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MarketplaceContext context)
        {
            _logger = logger;
            Context = context;
        }

        public void OnGet()
        {
            UserName = "Вход/Регистрация";
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
                return Page();

            if(Context != null && Context.Owners != null)
            {
                Context.Owners.Add(
                    new Owner()
                    {
                        Name = "Vlad",
                        City = "Izhevsk",
                        PhoneNumber = "89120296901",
                        Email = "vladmel.melnikov@yandex.ru"
                    });
                Context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}