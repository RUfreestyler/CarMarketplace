using CarMarketplace.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarMarketplace.Pages.Application
{
    [Authorize]
    public class DeletePurchaseRequestModel : PageModel
    {
        readonly IRepository repository;

        public DeletePurchaseRequestModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet()
        {
            int.TryParse(HttpContext.Request.RouteValues["id"].ToString(), out int requestId);
            var pr = repository.GetAllPurchaseRequests()
                .Where(x => x.ID == requestId)
                .FirstOrDefault();
            repository.Remove(pr);
            return RedirectToPage("MyPurchaseRequests");
        }
    }
}