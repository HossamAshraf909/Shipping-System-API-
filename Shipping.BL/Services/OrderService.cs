using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Order;
using Shipping.BL.Services.Imodel;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadOrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadOrderDTO>>(orders);
        }

        public async Task<ReadOrderDTO?> GetOrderByIdAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            return _mapper.Map<ReadOrderDTO>(order);
        }
       public async Task<List<ReadOrderDTO>> GetOrderByStatusAsync(string Status)
        {
            var orders= await _unitOfWork.Orders.GetOrderByStatusAsync(Status);
            return _mapper.Map<List<ReadOrderDTO>>(orders);
        }

        public async Task AddOrderAsync(AddOrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var city = await _unitOfWork.Cities.GetByIdAsync(orderDto.CityId);
            var shippingType = await _unitOfWork.ShippingTypes.GetByIdAsync(orderDto.ShippingTypeId);
            order.ShippingPrice = (city.ShippingPrice+shippingType.ShippingPrice);
            if(orderDto.IsVillageDelivery== true)
            {
                var deliveryTovillage = await _unitOfWork.VillageDelivery.GetAllAsync();
                var delivery= deliveryTovillage.First();    
                order.ShippingPrice += delivery.Price;
            }
            var wieghtSetting= await _unitOfWork.WeightPrices.GetAllAsync();
            var settingOfWieght = wieghtSetting.First();
                order.WeightPriceId = settingOfWieght.Id;
            if (order.TotalWeight > settingOfWieght.DefaultWeight)
            {
                var ExtraKilos= (int)(order.TotalWeight)-settingOfWieght.DefaultWeight;
                order.ShippingPrice += (settingOfWieght.ExtraPricePerKilo)*ExtraKilos;
            }
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
        }

        public async Task UpdateOrderAsync(int orderId, AddOrderDTO orderDto)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order != null)
            {
                _mapper.Map(orderDto, order);
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _unitOfWork.Orders.DeleteAsync(orderId);
            await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
        }
    }
}
