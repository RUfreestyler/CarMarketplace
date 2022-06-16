using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Models;
using CarMarketplace.Services;
using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class PlaceAdvertisementModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "¬ведите марку")]
        public string Make { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите модель")]
        public string Model { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите год выпуска")]
        public string YearOfManufacture { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите мощность двигател€ в л.с.")]
        public string EnginePower { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ыберите тип трансмиссии")]
        public TransmissionType Transmission { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "”кажите тип машины")]
        public CarType Type { get; set; }

        [BindProperty]
        public string? Kilometrage { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "”кажите желаемую цену")]
        public decimal Price { get; set; }

        readonly IRepository repository;

        public PlaceAdvertisementModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();
            var car = new Car()
            {
                Make = Make,
                Model = Model,
                YearOfManufacture = YearOfManufacture,
                EnginePower = EnginePower,
                Transmission = Transmission,
                Type = Type,
                Kilometrage = string.IsNullOrWhiteSpace(Kilometrage) ? 
                    "0" : Kilometrage,
                Price = Price,
                OwnerID = int.Parse(HttpContext.User.FindFirst("ID").Value)
            };
            repository.Add(car);
            var ad = new Advertisement()
            {
                Description = Description,
                Title = $"{Make} {Model}, {YearOfManufacture}",
                OwnerID = int.Parse(HttpContext.User.FindFirst("ID").Value),
                ProductID = car.ID,
                InsertationDate = DateTime.Now
            };
            repository.Add(ad);
            return Redirect("MyAdvertisements");
        }
    }
}
