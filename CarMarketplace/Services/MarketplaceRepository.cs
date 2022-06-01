using CarMarketplace.Models;

namespace CarMarketplace.Services
{
    public class MarketplaceRepository : IRepository
    {
        private readonly MarketplaceContext context;

        public MarketplaceRepository(MarketplaceContext context)
        {
            this.context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IMarketplaceModel
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<Advertisement> GetAllAdvertisements()
        {
            var enumerator = context.Advertisements?.AsEnumerable().GetEnumerator();
            while(enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public IEnumerable<Car> GetAllCars()
        {
            var enumerator = context.Cars?.AsEnumerable().GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            var enumerator = context.Owners?.AsEnumerable().GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IMarketplaceModel
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void RemoveAt<TEntity>(int id) where TEntity : class, IMarketplaceModel
        {
            var entityToRemove = context.Find<TEntity>(id);
            if (entityToRemove != null)
            {
                context.Remove(entityToRemove);
                context.SaveChanges();
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IMarketplaceModel
        {
            context.Attach(entity);
            context.SaveChanges();
        }
    }
}
