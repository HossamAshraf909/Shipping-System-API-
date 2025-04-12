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




        public async Task<Dictionary<OrderStatus, int>> GetOrderCountsByStatus(string userId, string userRole)
        {
            var query = _unitOfWork.Orders.GetAll();

            if (userRole == "Merchant")
                query = query.Where(o => o.Merchant.UserID == userId);
            else if (userRole == "Delivery")
                query = query.Where(o => o.Delivery.UserID == userId);

            var result = await query
                .GroupBy(o => o.orderStatus)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionaryAsync(g => g.Status, g => g.Count);

            var allStatuses = Enum.GetValues(typeof(OrderStatus))
                                   .Cast<OrderStatus>()
                                   .ToDictionary(status => status, status => 0);

            foreach (var status in result)
            {
                allStatuses[status.Key] = status.Value;
            }

            return allStatuses;
        }





    }
}
