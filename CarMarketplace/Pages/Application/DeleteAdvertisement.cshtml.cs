using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class DeleteAdvertisementModel : PageModel
    {
        readonly IRepository repository;

        public DeleteAdvertisementModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet()
        {
            int.TryParse(HttpContext.Request.RouteValues["id"].ToString(), out int adId);
            var ad = repository.GetAllAdvertisements()
                .Where(x => x.ID == adId)
                .FirstOrDefault();
            var car = repository.GetAllCars()
                .Where(x => x.ID == ad.ProductID)
                .FirstOrDefault();
            repository.RemoveAt<Advertisement>(ad.ID);
            repository.RemoveAt<Car>(car.ID);
            return RedirectToPage("MyAdvertisements");
        }
    }
}