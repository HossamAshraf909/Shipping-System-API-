using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Repositories;
using Shipping.DAL.Persistent.Repositries;

public interface IUnitOfWork : IDisposable
{
    ProductRepository Products { get; }
    OrderProductRepository OrderProducts { get; }
    OrderRepository Orders { get; }  

    IGenericRepository<City> Cities { get; }
    IGenericRepository<Governorate> Governorates { get; }
    IGenericRepository<Branches> Branches { get; }
    IGenericRepository<ShippingType> ShippingTypes { get; }
    IGenericRepository<WeightPrice> WeightPrices { get; }

    Task<int> SaveChangesAsync();
}
