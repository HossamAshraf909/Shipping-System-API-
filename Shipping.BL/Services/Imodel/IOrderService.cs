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

        Task<IEnumerable<ReadOrderDTO>> GetAllOrdersAsync();
        Task<ReadOrderWithProducts?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(AddOrderDTO order);
        Task UpdateOrderAsync(int orderId, AddOrderDTO order);
        Task DeleteOrderAsync(int orderId);

    }

}
