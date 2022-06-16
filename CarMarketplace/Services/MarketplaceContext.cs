using CarMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMarketplace.Services
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
            
        }
    }
}
