using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Models;
using CarMarketplace.Services;

namespace CarMarketplace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string? UserName { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if(string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "Вход/Регистрация";
                return;
            }     
        }
    }
}