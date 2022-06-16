using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.ViewModels;

namespace CarMarketplace.Pages.Application
{
    public class AdvertisementModel : PageModel
    {
        public SingleAdViewModel SingleAdViewModel { get; set; }

        readonly IRepository repository;

        public AdvertisementModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            var ad = repository.GetAllAdvertisements()
                .Where(x => x.ID == int.Parse(HttpContext.Request.RouteValues["id"].ToString()))
                .FirstOrDefault();
            if(ad != null)
            {
                var car = repository.GetAllCars().Where(x => x.ID == ad.ProductID).FirstOrDefault();
                var owner = repository.GetAllOwners().Where(x => x.ID == ad.OwnerID).FirstOrDefault();
                SingleAdViewModel = new SingleAdViewModel()
                {
                    Title = ad.Title,
                    Price = car.Price,
                    InsertationDate = ad.InsertationDate,
                    Name = owner.Name,
                    Phone = owner.PhoneNumber,
                    YearOfManufacture = car.YearOfManufacture,
                    EnginePower = car.EnginePower,
                    Kilometrage = car.Kilometrage,
                    Transmission = car.Transmission,
                    Type = car.Type,
                    Description = ad.Description
                };
            }           
        }
    }
}