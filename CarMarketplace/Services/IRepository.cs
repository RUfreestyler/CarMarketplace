using CarMarketplace.Models;

namespace CarMarketplace.Services
{
    public interface IRepository
    {
        public IEnumerable<Owner> GetAllOwners();
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Advertisement> GetAllAdvertisements();
        public void Add<TEntity>(TEntity owner)
            where TEntity : class, IMarketplaceModel;
        public void RemoveAt<TEntity>(int id)
            where TEntity : class, IMarketplaceModel;
    }
}
