﻿using Shipping.DAL.Persistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Repositries.Irepo
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByMerchantIdAsync(int MerchantID);
            IQueryable<Order> GetAll(); 
    }

}
