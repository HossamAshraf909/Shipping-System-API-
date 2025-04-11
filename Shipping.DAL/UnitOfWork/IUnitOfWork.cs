﻿using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;
using Shipping.DAL.Persistent.Repositories;
using Shipping.DAL.Persistent.Repositries;

public interface IUnitOfWork : IDisposable
{
    ProductRepository Products { get; }
    OrderProductRepository OrderProducts { get; }
    OrderRepository Orders { get; }

     IGenericRepository<VillageDelivery> VillageDelivery { get; }
     IGenericRepository<SpecialPackages> SpecialPackage { get; }

    IGenericRepository<City> Cities { get; }
    IGenericRepository<Governorate> Governorates { get; }
    IGenericRepository<Branches> Branches { get; }
    IGenericRepository<ShippingType> ShippingTypes { get; }
    IGenericRepository<WeightPrice> WeightPrices { get; }

    IGenericRepository<Delivery> Delivery { get; }
    
    IGenericRepository<Employee> Employee { get; }


    IGenericRepository<Merchant> Merchant { get; }

    Task<int> SaveChangesAsync();
}
