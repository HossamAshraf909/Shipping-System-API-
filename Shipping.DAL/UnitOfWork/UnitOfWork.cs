using System;
using System.Threading.Tasks;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositories;
using Shipping.DAL.Persistent.Repositries.Irepo;
using Shipping.DAL.Persistent.Repositries;

namespace Shipping.DAL.Persistent.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

<<<<<<< HEAD
        private readonly ShippingContext context;
        private ProductRepositry _ProductRepositry;
        private OrderProductRepositry _OrderProductRepositry;
        private GenericRepositry<City> cityRep;
        private GenericRepositry<Governorate> govRep;
        private GenericRepositry<Branches> branchRep;
        private GenericRepositry<ShippingType> _ShippingTypeRepositry;
        GenericRepositry<WeightPrice> weightPriceRepo;
        private GenericRepositry<SpecialPackages> _specialPackagesRepo;
        private GenericRepositry<VillageDelivery> _villageDeliveryRepo;
        public UnitOfWork( ShippingContext context)
=======
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
        public UnitOfWork(ShippingContext context)
>>>>>>> master
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
<<<<<<< HEAD
        
        public GenericRepositry<City> CityRep
        {
            get
            {
                if (cityRep == null)
                    cityRep = new GenericRepositry<City>(context);
                return cityRep;

            }
        }

        public GenericRepositry<Governorate> GovRep
        {
            get
            {
                if (govRep == null)
                    govRep = new GenericRepositry<Governorate>(context);
                return govRep;

            }
        }

        public GenericRepositry<Branches> BranchRep
        {
            get
            {
                if (branchRep == null)
                    branchRep = new GenericRepositry<Branches>(context);
                return branchRep;

            }
        }

        public ProductRepositry ProductRepositry
        {
            get
            {
                if (_ProductRepositry == null)
                    _ProductRepositry = new ProductRepositry(context);
                return _ProductRepositry;
            }
        }

        public OrderProductRepositry orderProductRepositry
        {
            get
            {
                if (_OrderProductRepositry == null)
                    _OrderProductRepositry = new(context);
                return _OrderProductRepositry;
            }
        }

        public GenericRepositry<ShippingType> shippingTypeRepositry
        {
            get
            {
                if (_ShippingTypeRepositry == null)
                    _ShippingTypeRepositry = new(context);
                return _ShippingTypeRepositry;
            }
        }

        public GenericRepositry<VillageDelivery> villageDelivery
        {
            get
            {
                if (_villageDeliveryRepo == null)
                    _villageDeliveryRepo = new GenericRepositry<VillageDelivery>(context);
                return _villageDeliveryRepo;
            }
        }
        public GenericRepositry<SpecialPackages> specialPackage
        {
            get
            {
                if (_specialPackagesRepo == null)
                    _specialPackagesRepo = new GenericRepositry<SpecialPackages>(context);
                return _specialPackagesRepo;
            }
        }
        public void Save()
=======

        public ProductRepository Products =>
            _products ??= new ProductRepository(_context);
        
        
        public IGenericRepository<SpecialPackages> SpecialPackage =>
            _specialPackages ??= new GenericRepository<SpecialPackages>(_context);

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


        public async Task<int> SaveChangesAsync()
>>>>>>> master
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
