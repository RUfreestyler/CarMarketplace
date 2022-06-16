using CarMarketplace.Models;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class PlacePurchaseRequestModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "������� �����")]
        public string Make { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ������")]
        public string Model { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ��� �������")]
        public int YearOfManufactureLowerBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ��� �������")]
        public int YearOfManufactureUpperBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� �������� ��������� � �.�.")]
        public int EnginePowerLowerBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� �������� ��������� � �.�.")]
        public int EnginePowerUpperBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "�������� ��� �����������")]
        public TransmissionType Transmission { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ��� ������")]
        public CarType Type { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ����������")]
        public int KilometrageLowerBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� ����������")]
        public int KilometrageUpperBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� �������� ����")]
        public decimal PriceLowerBound { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������� �������� ����")]
        public decimal PriceUpperBound { get; set; }

        readonly IRepository repository;

        public PlacePurchaseRequestModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();
            var userId = int.Parse(HttpContext.User.FindFirst("ID").Value);
            var purchaseRequest = new PurchaseRequest()
            {
                City = repository.GetAllOwners().Where(x => x.ID == userId).FirstOrDefault().City,
                Make = Make,
                Model = Model,
                YearOfManufactureLowerBound = YearOfManufactureLowerBound,
                YearOfManufactureUpperBound = YearOfManufactureUpperBound,
                EnginePowerLowerBound = EnginePowerLowerBound,
                EnginePowerUpperBound = EnginePowerUpperBound,
                Type = Type,
                Transmission = Transmission,
                KilometrageLowerBound = KilometrageLowerBound,
                KilometrageUpperBound = KilometrageUpperBound,
                PriceLowerBound = PriceLowerBound,
                PriceUpperBound = PriceUpperBound,
                OwnerID = userId
            };
            repository.Add(purchaseRequest);
            return RedirectToPage("../Index");
        }
    }
}
