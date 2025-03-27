using Shipping.BL.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services.Imodel
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(OrderDTO order);
        Task UpdateOrderAsync(int orderId, OrderDTO order);
        Task DeleteOrderAsync(int orderId);

    }

}
