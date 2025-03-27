using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositories;

public class OrderProductRepository : GenericRepository<Order_Product>
{
    public OrderProductRepository(ShippingContext context) : base(context)
    {
    }

    public async Task DeleteProductFromOrderAsync(int id)
    {
        var orderProduct = await GetByIdAsync(id);
        if (orderProduct == null)
        {
            throw new ArgumentException($"Order_Product with ID {id} not found.");
        }

        await DeleteAsync(id); 
         
        if (orderProduct.Product != null) 
        {
            _context.Products.Remove(orderProduct.Product);
        }
        
        await SaveChangesAsync(); 
    }
}
