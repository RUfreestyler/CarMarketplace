using CarMarketplace.Models;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class EditPurchaseRequestModel : PageModel
    {
        [BindProperty]
        public string Make { get; set; }

        [BindProperty]
        public string Model { get; set; }

        [BindProperty]
        public int YearOfManufactureLowerBound { get; set; }

        [BindProperty]
        public int YearOfManufactureUpperBound { get; set; }

        [BindProperty]
        public int EnginePowerLowerBound { get; set; }

        [BindProperty]
        public int EnginePowerUpperBound { get; set; }

        [BindProperty]
        public int KilometrageLowerBound { get; set; }

        [BindProperty]
        public int KilometrageUpperBound { get; set; }

        [BindProperty]
        public TransmissionType? Transmission { get; set; }

        [BindProperty]
        public CarType? Type { get; set; }

        [BindProperty]
        public decimal PriceLowerBound { get; set; }

        [BindProperty]
        public decimal PriceUpperBound { get; set; }

        readonly IRepository repository;

        public EditPurchaseRequestModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            var prId = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            var pr = repository.GetAllPurchaseRequests()
                .Where(x => x.ID == prId)
                .FirstOrDefault();
            Make = pr.Make;
            Model = pr.Model;
            YearOfManufactureLowerBound = pr.YearOfManufactureLowerBound;
            YearOfManufactureUpperBound = pr.YearOfManufactureUpperBound;
            EnginePowerLowerBound = pr.YearOfManufactureLowerBound;
            EnginePowerUpperBound = pr.EnginePowerUpperBound;
            KilometrageLowerBound = pr.KilometrageLowerBound;
            KilometrageUpperBound = pr.KilometrageUpperBound;
            Type = pr.Type;
            Transmission = pr.Transmission;
            PriceLowerBound = pr.PriceLowerBound;
            PriceUpperBound = pr.PriceUpperBound;
        }

        public void OnPost()
        {
            var prId = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            var pr = repository.GetAllPurchaseRequests()
                .Where(x => x.ID == prId)
                .FirstOrDefault();
            if(pr != null)
            {
                pr.Make = Make;
                pr.Model = Model;
                pr.YearOfManufactureLowerBound = YearOfManufactureLowerBound;
                pr.YearOfManufactureUpperBound = YearOfManufactureUpperBound;
                pr.KilometrageLowerBound = KilometrageLowerBound;
                pr.KilometrageUpperBound = KilometrageUpperBound;
                pr.EnginePowerLowerBound = EnginePowerLowerBound;
                pr.EnginePowerUpperBound = EnginePowerUpperBound;
                pr.Transmission = (TransmissionType)Transmission;
                pr.Type = (CarType)Type;
                pr.PriceLowerBound = PriceLowerBound;
                pr.PriceUpperBound = PriceUpperBound;
                repository.Update(pr);
            }
        }
    }
}
