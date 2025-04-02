using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.OrderProduct;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class OrderProductService
    {

        private readonly IUnitOfWork unit;
        private readonly IMapper map;

        public OrderProductService(IUnitOfWork unit ,IMapper map)

        {
            this.unit = unit;
            this.map = map;
        }

        public async Task<List<ReadOrderProductDTO>> GetAllAsync()
        {
            var orderProducts = await unit.OrderProducts.GetAllAsync();
            return map.Map<List<ReadOrderProductDTO>>(orderProducts);
        }
        public async Task<ReadOrderProductDTO?> GetByIdAsync(int id)
        {
            var orderProduct = await unit.OrderProducts.GetByIdAsync(id);
            return orderProduct == null ? null : map.Map<ReadOrderProductDTO>(orderProduct);
        }
        public async Task AddAsync(List<Order_Product> order_Products)
        {
            foreach(var order_Product in order_Products)
            {
                await unit.OrderProducts.AddAsync(order_Product);
            }
        }
    }
}
