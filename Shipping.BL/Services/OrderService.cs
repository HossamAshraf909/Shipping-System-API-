using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Order;
using Shipping.BL.Services.Imodel;
using Shipping.DAL.Persistent.Repositries;
using Shipping.DAL.Persistent.Repositries.Irepo;

namespace Shipping.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task AddOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(int orderId, OrderDTO orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order != null)
            {
                _mapper.Map(orderDto, order);
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
