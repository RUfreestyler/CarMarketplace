using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    public class PlaceAdvertisementModel : PageModel
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? YearOfManufacture { get; set; }
        public string? EnginePower { get; set; }
        public string? Transmission { get; set; }
        public string? TechnicalState { get; set; }
        public decimal Price { get; set; }
        public int OwnerID { get; set; }

        public void OnGet()
        {
        }
    }
}
