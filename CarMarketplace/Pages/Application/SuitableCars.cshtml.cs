using CarMarketplace.Services;
using CarMarketplace.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class SuitableCarsModel : PageModel
    {
        public List<AdsViewModel> AdsViewModel { get; set; }

        readonly IRepository repository;

        public SuitableCarsModel(IRepository repository)
        {
            this.repository = repository;
            AdsViewModel = new List<AdsViewModel>();
        }

        public void OnGet()
        {
            var prId = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            var pr = repository.GetAllPurchaseRequests()
                .Where(x => x.ID == prId)
                .FirstOrDefault();
            var userId = int.Parse(HttpContext.User.FindFirst("ID").Value);
            AdsViewModel.Clear();
            foreach (var car in repository.GetAllCars())
            {
                if (car.Make == pr.Make && car.Model == pr.Model && 
                    int.Parse(car.YearOfManufacture) >= pr.YearOfManufactureLowerBound && int.Parse(car.YearOfManufacture) <= pr.YearOfManufactureUpperBound &&
                    int.Parse(car.EnginePower) >= pr.EnginePowerLowerBound && int.Parse(car.EnginePower) <= pr.EnginePowerUpperBound &&
                    int.Parse(car.Kilometrage) >= pr.KilometrageLowerBound && int.Parse(car.Kilometrage) <= pr.KilometrageUpperBound &&
                    car.Transmission == pr.Transmission && car.Type == pr.Type &&
                    car.Price >= pr.PriceLowerBound && car.Price <= pr.PriceUpperBound &&
                    car.OwnerID != userId)
                {
                    var ad = repository.GetAllAdvertisements().Where(x => x.ProductID == car.ID).FirstOrDefault();
                    AdsViewModel.Add(new AdsViewModel()
                    {
                        ID = ad.ID,
                        Title = $"{car.Make} {car.Model}, {car.YearOfManufacture}",
                        InsertationDate = ad.InsertationDate,
                        Price = car.Price,
                        OwnerID = car.OwnerID,
                        ProductID = car.ID
                    });
                }
            }
        }
    }
}
