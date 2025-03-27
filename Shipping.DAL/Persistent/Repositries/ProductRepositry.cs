
namespace Shipping.DAL.Persistent.Repositries
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Data.Context;
    using Shipping.DAL.Persistent.Repositories;

    public class ProductRepository : GenericRepository<Product>
{
        public ProductRepository(ShippingContext context) : base(context)
    {
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product == null)
        {
                throw new ArgumentException($"Product with ID {id} not found.");
        }

           await DeleteAsync(id); 
            await SaveChangesAsync(); 
        }
    }

}
