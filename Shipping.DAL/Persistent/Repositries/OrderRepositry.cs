using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositories;
using Shipping.DAL.Persistent.Repositries.Irepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Repositries
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShippingContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerName)
        {
            return await _context.Orders.Where(o => o.CustomerName == customerName).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderByStatusAsync(string Status)
        {
            return await _context.Orders.Where(o => o.orderStatus.ToString() == Status).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderByDateAsync(DateTime FromDate, DateTime ToDate)
        {
            return await _context.Orders.Where(o => o.OrderDate.Date >= FromDate.Date && o.OrderDate.Date<=ToDate.Date).ToListAsync();
        }

       public IQueryable<Order> GetAll()
        {
            return _context.Orders;

        }

      
    }
}
