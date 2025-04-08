using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;
using Shipping.DAL.Persistent.Data.ModelConfigruation;

namespace Shipping.DAL.Persistent.Data.Context
{

    public class ShippingContext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ShippingContext(DbContextOptions<ShippingContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(SoftDeleteConfiguration.CreateFilterExpression(entityType.ClrType));
                }
            }
        }



       public DbSet<Branches> Branches { get; set; }
       public DbSet<City> Cities { get; set; }
       public DbSet<Governorate> governorates { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<Order_Product> OrderProducts { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<ShippingType> shippingTypes { get; set; }
       public DbSet<SpecialPackages> specialPackages { get; set; }
       public DbSet<VillageDelivery> villageDeliveries { get; set; }
       public DbSet<WeightPrice> weightPrices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<MerchantBranch> MerchantBranches { get; set; }
        public DbSet<DeliveryBranch> DeliveryBranches { get; set; }
    }
}
