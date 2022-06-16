using CarMarketplace.Models;

namespace CarMarketplace.Services
{
    public interface IRepository
    {
        public IEnumerable<Owner> GetAllOwners();
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Advertisement> GetAllAdvertisements();
        public IEnumerable<PurchaseRequest> GetAllPurchaseRequests();
        public void Add<TEntity>(TEntity entity)
            where TEntity : class, IMarketplaceModel;
        public void Remove<TEntity>(TEntity entity)
            where TEntity : class, IMarketplaceModel;
        public void RemoveAt<TEntity>(int id)
            where TEntity : class, IMarketplaceModel;
        public void Update<TEntity>(TEntity? entity)
            where TEntity : class, IMarketplaceModel;
    }
}
