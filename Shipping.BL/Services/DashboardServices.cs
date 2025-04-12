using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services
{
    public class DashboardServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public async Task<Dictionary<OrderStatus, int>> GetOrderCountsByStatus(string userId)
        {
            return await _unitOfWork.Orders.GetAll()
                .Where(o => o.MerchantId.ToString() == userId)
                .GroupBy(o => o.orderStatus)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(g => g.Status, g => g.Count);
        }



    }
}
