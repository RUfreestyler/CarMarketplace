using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.Services;
using CarMarketplace.ViewModels;

namespace CarMarketplace.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public bool UserAuthorized { get; set; }

        private readonly IRepository repository;
        public IEnumerable<AdsViewModel>? AdsViewModel { get; set; }

        public IndexModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            var sortState = ((int)SortState.Date);
            if(HttpContext.Request.RouteValues["sortState"] != null)
            {
                sortState = int.Parse(HttpContext.Request.RouteValues["sortState"].ToString());
            }
            AdsViewModel = new List<AdsViewModel>();
            foreach (var ad in repository.GetAllAdvertisements())
            {
                AdsViewModel = AdsViewModel.Append(new AdsViewModel()
                {
                    ID = ad.ID,
                    Title = ad.Title,
                    Price = repository.GetAllCars().Where(car => car.ID == ad.ProductID).FirstOrDefault().Price,
                    ProductID = ad.ProductID,
                    OwnerID = ad.OwnerID,
                    InsertationDate = ad.InsertationDate
                });
            }
            AdsViewModel = sortState switch
            {
                ((int)SortState.Date) => AdsViewModel.OrderByDescending(x => x.InsertationDate),
                ((int)SortState.PriceAsc) => AdsViewModel.OrderBy(x => x.Price),
                ((int)SortState.PriceDesc) => AdsViewModel.OrderByDescending(x => x.Price),
                _ => AdsViewModel.OrderByDescending(x => x.InsertationDate)
            };
        }
    }
}