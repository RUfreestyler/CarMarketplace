using CarMarketplace.Models;

namespace CarMarketplace.Services
{
    public interface IRepository
    {
        public IEnumerable<Owner> GetAllOwners();
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Advertisement> GetAllAdvertisements();
        public void AddOwner(Owner owner);
        public void RemoveOwnerAt(int id);
        public void AddCar(Car car);
        public void RemoveCarAt(int id);
        public void AddAdvertisement(Advertisement advertisement);
        public void RemoveAdvertisementAt(int id);
        public void SaveChanges();
    }
}
