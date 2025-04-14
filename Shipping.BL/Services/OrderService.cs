using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Order;
using Shipping.BL.Services.Imodel;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Enums;
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
        public async Task<EditOrderDTO?> GetOrderByIdAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            return _mapper.Map<EditOrderDTO>(order);
        }
        public async Task<PaginatedOrderDTO> GetOrderByStatusAsync(string Status,int pageSize , int pageNumber)
        {
            var orders= await _unitOfWork.Orders.GetOrderByStatusAsync(Status);
            var paginatedOrders = new PaginatedOrderDTO();
            paginatedOrders.TotalRecords = orders.Count();
            paginatedOrders.TotalPages = (int)Math.Ceiling((double)paginatedOrders.TotalRecords / pageSize);
            paginatedOrders.Orders =_mapper.Map<List<ReadOrderDTO>>(orders);
            paginatedOrders.Orders = paginatedOrders.Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return paginatedOrders;
        }
        public async Task AddOrderAsync(AddOrderDTO orderDto)
        {
            var merchant = await _unitOfWork.Merchant.GetByIdAsync(orderDto.MerchentId);
            orderDto.Phonenumber = merchant.User.PhoneNumber;
            orderDto.Address = merchant.User.Address;
            var order = _mapper.Map<Order>(orderDto);
            if (merchant == null) throw new Exception("Merchant not found.");
            var city = await _unitOfWork.Cities.GetByIdAsync(orderDto.CityId);
            var shippingType = await _unitOfWork.ShippingTypes.GetByIdAsync(orderDto.ShippingTypeId);
            order.ShippingPrice = (city.ShippingPrice+shippingType.ShippingPrice);

            var Merchant = await _unitOfWork.Merchant.GetByIdAsync(orderDto.MerchentId);
            foreach (var specialPackage in Merchant.SpecialPackages)
            {
                if (orderDto.CityId == specialPackage.cityID && orderDto.GovernorateId == specialPackage.governorateID)
                {
                    order.ShippingPrice = specialPackage.ShippingPrice;
                    break;
                }
            }
            if (orderDto.IsVillageDelivery== true)
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
            var ListofProducts = new List<Product>();
            var OrderProducts = new List<Order_Product>();
            foreach (var _product in orderDto.Products)
            {
                var product = _mapper.Map<Product>(_product);
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
                ListofProducts.Add(product);
            }
            var AddedOrder = await _unitOfWork.Orders.GetByIdAsync(order.Id);

            foreach (var product in ListofProducts)
            {
                var orderProduct = new Order_Product
                {
                    OrderId = AddedOrder.Id,
                    ProductId = product.Id,
                };
                await _unitOfWork.OrderProducts.AddAsync(orderProduct);
            }
                await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(int orderId, EditOrderDTO orderDto)
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
        public async Task AssignOrderToDelivery(int DeliveyId, int OrderId)
        {
           var Delivery = await _unitOfWork.Delivery.GetByIdAsync(DeliveyId);
            if(Delivery!= null)
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(OrderId);
                if (order != null)
                {
                    order.DeliveryId = DeliveyId;
                    order.orderStatus = OrderStatus.Delivered;
                    await _unitOfWork.Orders.UpdateAsync(order);
                    await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
                }
            }
        }
        public async Task UpdateOrderStatus(int OrderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(OrderId);
            if (order != null)
            {
                order.orderStatus = OrderStatus.Pending;
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.SaveChangesAsync();  // Ensure changes are saved
            }
        }
        public async Task<PaginatedOrderDTO> GetPaginatedAsync(int page, int pageSize)
        {
            var _PaginatedOrders= new PaginatedOrderDTO();
            var orders= await _unitOfWork.Orders.GetPaginatedAsync(page, pageSize);
            _PaginatedOrders.TotalRecords = orders.TotalRecords;
            _PaginatedOrders.TotalPages = orders.TotalPages;
            foreach (var order in orders.Data)
            {
                var orderDto = _mapper.Map<ReadOrderDTO>(order);
                _PaginatedOrders.Orders.Add(orderDto);
            }
            var paginatedOrders = _mapper.Map<IEnumerable<ReadOrderDTO>>(orders.Data);
            return _PaginatedOrders ;
        }
        public async Task<List<ReadOrderDTO>> GetOrderByMerchantId(int MerchantId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByMerchantIdAsync(MerchantId);
            return _mapper.Map<List<ReadOrderDTO>>(orders);
        }
        public async Task<List<ReadOrderDTO>> GetOrderbyDeliveryId(int deliveryId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByDeliveryIdAsync(deliveryId);
            return _mapper.Map<List<ReadOrderDTO>>(orders);
        }

    }
}
