using System;
using System.Threading.Tasks;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositories;
using Shipping.DAL.Persistent.Repositries.Irepo;
using Shipping.DAL.Persistent.Repositries;
using Shipping.DAL.Entities.Identity;

namespace Shipping.DAL.Persistent.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ShippingContext _context;

        private ProductRepository? _products;
        private OrderProductRepository? _orderProducts;
        private OrderRepository? _orders;
        private IGenericRepository<City>? _cities;
        private IGenericRepository<Governorate>? _governorates;
        private IGenericRepository<Branches>? _branches;
        private IGenericRepository<ShippingType>? _shippingTypes;
        private IGenericRepository<WeightPrice>? _weightPrices;
        private IGenericRepository<VillageDelivery>? _villageDelivery;
        private IGenericRepository<SpecialPackages>? _specialPackages;
        private IGenericRepository<Merchant>? _merchent;
        private IGenericRepository<Delivery>? _delivery;
        private IGenericRepository<Employee>? _employee;
        private IGenericRepository<DeliveryBranch>? _deliveryBranches;


        public UnitOfWork(ShippingContext context)

        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public ProductRepository Products =>
            _products ??= new ProductRepository(_context);
        
        
        public IGenericRepository<SpecialPackages> SpecialPackage =>
            _specialPackages ??= new GenericRepository<SpecialPackages>(_context);

        public IGenericRepository<Merchant> Merchant =>
            _merchent ??= new GenericRepository<Merchant>(_context);
        public IGenericRepository<Delivery> Delivery =>
            _delivery ??= new GenericRepository<Delivery>(_context);

        public IGenericRepository<Employee> Employee =>
           _employee ??= new GenericRepository<Employee>(_context);
        public OrderProductRepository OrderProducts =>
            _orderProducts ??= new OrderProductRepository(_context);

        public OrderRepository Orders =>
            _orders ??= new OrderRepository(_context);

        public IGenericRepository<City> Cities =>
     _cities ??= new GenericRepository<City>(_context);

        public IGenericRepository<Governorate> Governorates =>
            _governorates ??= new GenericRepository<Governorate>(_context);

        public IGenericRepository<VillageDelivery> VillageDelivery =>
            _villageDelivery ??= new GenericRepository<VillageDelivery>(_context);
        public IGenericRepository<Branches> Branches =>
            _branches ??= new GenericRepository<Branches>(_context);

        public IGenericRepository<ShippingType> ShippingTypes =>
            _shippingTypes ??= new GenericRepository<ShippingType>(_context);

        public IGenericRepository<WeightPrice> WeightPrices =>
            _weightPrices ??= new GenericRepository<WeightPrice>(_context);
        public IGenericRepository<DeliveryBranch> DeliveryBranches =>
            _deliveryBranches ??= new GenericRepository<DeliveryBranch>(_context);


        public async Task<int> SaveChangesAsync()

        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
