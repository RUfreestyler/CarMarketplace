using CarMarketplace.Models;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class PurchaseRequestModel : PageModel
    {
        readonly IRepository repository;

        public PurchaseRequest PurchaseRequest { get; set; }

        public Owner Owner { get; set; }

        public PurchaseRequestModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            var prId = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            PurchaseRequest = repository.GetAllPurchaseRequests()
                .Where(x => x.ID == prId)
                .FirstOrDefault();

            var ownerId = int.Parse(HttpContext.User.FindFirst("ID").Value);
            Owner = repository.GetAllOwners().Where(x => x.ID == ownerId).FirstOrDefault();
        }
    }
}
