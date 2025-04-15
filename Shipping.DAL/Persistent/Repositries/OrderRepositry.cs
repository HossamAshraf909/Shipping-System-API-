using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Enums;
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

        public async Task<IEnumerable<Order>> GetOrdersByMerchantIdAsync(int merchentId)   

        {
            return await _context.Orders.Where(o => o.MerchantId == merchentId).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByDeliveryIdAsync(int deliveryid)
        {
            return await _context.Orders.Where(o => o.DeliveryId == deliveryid).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderByStatusAsync(OrderStatus Status)
        {
            return await _context.Orders.Where(o => o.orderStatus == Status).ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderByDateAsync(DateTime FromDate, DateTime ToDate)
        {
            return await _context.Orders.Where(o => o.OrderDate.Date >= FromDate.Date && o.OrderDate.Date<=ToDate.Date).ToListAsync();
        }

       public IQueryable<Order> GetAll()
        {
            return _context.Orders.AsQueryable();

        }

      

    }
}
