using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.ViewModels;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class MyAdvertisementsModel : PageModel
    {
        public List<AdsViewModel> AdsViewModel { get; set; }

        readonly IRepository repository;

        public MyAdvertisementsModel(IRepository repository)
        {
            AdsViewModel = new List<AdsViewModel>();
            this.repository = repository;
        }

        public void OnGet()
        {
            AdsViewModel.Clear();
            foreach (var ad in repository.GetAllAdvertisements())
            {
                if(ad.OwnerID == int.Parse(HttpContext.User.FindFirst("ID").Value))
                    AdsViewModel.Add(new AdsViewModel()
                    {
                        ID = ad.ID,
                        Title = ad.Title,
                        Price = repository.GetAllCars().Where(car => car.ID == ad.ProductID).FirstOrDefault().Price,
                        ProductID = ad.ProductID,
                        OwnerID = ad.OwnerID,
                        InsertationDate = ad.InsertationDate
                    });
            }
        }
    }
}
