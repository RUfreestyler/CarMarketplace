using Microsoft.AspNetCore.Mvc.RazorPages;
using CarMarketplace.ViewModels;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class MyPurchaseRequestsModel : PageModel
    {
        public List<PurchaseRequestViewModel> PurchaseRequestsViewModel { get; set; }

        readonly IRepository repository;

        public MyPurchaseRequestsModel(IRepository repository)
        {
            PurchaseRequestsViewModel = new List<PurchaseRequestViewModel>();
            this.repository = repository;
        }

        public void OnGet()
        {
            PurchaseRequestsViewModel.Clear();
            foreach (var pr in repository.GetAllPurchaseRequests())
            {
                if (pr.OwnerID == int.Parse(HttpContext.User.FindFirst("ID").Value))
                    PurchaseRequestsViewModel.Add(new PurchaseRequestViewModel()
                    {
                        ID = pr.ID,
                        Title = $"{pr.Make} {pr.Model}",
                        OwnerID = pr.OwnerID,
                    });
            }
        }
    }
}
