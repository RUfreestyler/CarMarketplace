using CarMarketplace.Models;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class EditAdvertisementModel : PageModel
    {
        [BindProperty]
        public string? Make { get; set; }

        [BindProperty]
        public string? Model { get; set; }

        [BindProperty]
        public string? YearOfManufacture { get; set; }

        [BindProperty]
        public string? EnginePower { get; set; }

        [BindProperty]
        public TransmissionType? Transmission { get; set; }

        [BindProperty]
        public CarType? Type { get; set; }

        [BindProperty]
        public string? Kilometrage { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public decimal? Price { get; set; }

        readonly IRepository repository;

        public EditAdvertisementModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            var ad = repository.GetAllAdvertisements()
                .Where(x => x.ID == int.Parse(HttpContext.Request.RouteValues["id"].ToString()))
                .FirstOrDefault();
            var car = repository.GetAllCars().Where(x => x.ID == ad.ProductID).FirstOrDefault();
            Make = car.Make;
            Model = car.Model;
            EnginePower = car.EnginePower;
            YearOfManufacture = car.YearOfManufacture;
            Kilometrage = car.Kilometrage;
            Transmission = car.Transmission;
            Type = car.Type;
            Price = car.Price;
            Description = ad.Description;
        }


        public void OnPost()
        {
            var ad = repository.GetAllAdvertisements()
                .Where(x => x.ID == int.Parse(HttpContext.Request.RouteValues["id"].ToString()))
                .FirstOrDefault();
            var car = repository.GetAllCars().Where(x => x.ID == ad.ProductID).FirstOrDefault();
            if (car != null)
            {
                car.Make = Make;
                car.Model = Model;
                car.YearOfManufacture = YearOfManufacture;
                car.EnginePower = EnginePower;
                car.Transmission = (TransmissionType)Transmission;
                car.Type = (CarType)Type;
                car.Price = (decimal)Price;
                car.Kilometrage = Kilometrage;
                repository.Update(car);
            }
            if(ad != null)
            {
                ad.Description = Description;
                ad.Title = $"{Make} {Model}, {YearOfManufacture}";
                repository.Update(ad);
            }
        }
    }
}