using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Entities;

namespace Shipping.DAL.Persistent.Data.Context
{
    public class ShippingContext:DbContext
    {
        public ShippingContext(DbContextOptions<ShippingContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // modelBuilder.ApplyConfiguration(new ProductOrderCon());
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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

    }
}
