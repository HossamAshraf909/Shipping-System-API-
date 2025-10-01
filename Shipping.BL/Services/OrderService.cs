using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.Result;
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
            return order == null ? null : _mapper.Map<EditOrderDTO>(order);
        }

        public async Task<PaginatedOrderDTO> GetOrderByStatusAsync(OrderStatus status, int pageSize, int pageNumber)
        {
            var orders = await _unitOfWork.Orders.GetOrderByStatusAsync(status);

            var paginatedOrders = new PaginatedOrderDTO
            {
                TotalRecords = orders.Count(),
                TotalPages = (int)Math.Ceiling((double)orders.Count() / pageSize),
                Orders = _mapper.Map<List<ReadOrderDTO>>(orders)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList()
            };

            return paginatedOrders;
        }

        public async Task AddOrderAsync(AddOrderDTO orderDto)
        {
            var merchant = await _unitOfWork.Merchant.GetByIdAsync(orderDto.MerchentId);
            if (merchant == null)
                throw new Exception("Merchant not found.");

            orderDto.Phonenumber = merchant.User?.PhoneNumber ?? string.Empty;
            orderDto.Address = merchant.User?.Address ?? string.Empty;

            var order = _mapper.Map<Order>(orderDto);

            var city = await _unitOfWork.Cities.GetByIdAsync(orderDto.CityId);
            var shippingType = await _unitOfWork.ShippingTypes.GetByIdAsync(orderDto.ShippingTypeId);

            order.ShippingPrice = (city?.ShippingPrice ?? 0) + (shippingType?.ShippingPrice ?? 0);

            foreach (var specialPackage in merchant.SpecialPackages)
            {
                if (orderDto.CityId == specialPackage.cityID &&
                    orderDto.GovernorateId == specialPackage.governorateID)
                {
                    order.ShippingPrice = specialPackage.ShippingPrice;
                    break;
                }
            }

            if (orderDto.IsVillageDelivery)
            {
                var deliveryToVillage = await _unitOfWork.VillageDelivery.GetAllAsync();
                var delivery = deliveryToVillage.FirstOrDefault();
                if (delivery != null)
                {
                    order.ShippingPrice += delivery.Price;
                }
            }

            var weightSettings = await _unitOfWork.WeightPrices.GetAllAsync();
            var settingOfWeight = weightSettings.FirstOrDefault();
            if (settingOfWeight != null)
            {
                order.WeightPriceId = settingOfWeight.Id;

                if (order.TotalWeight > settingOfWeight.DefaultWeight)
                {
                    var extraKilos = (int)order.TotalWeight - settingOfWeight.DefaultWeight;
                    order.ShippingPrice += settingOfWeight.ExtraPricePerKilo * extraKilos;
                }
            }

            await _unitOfWork.Orders.AddAsync(order);

            var products = new List<Product>();
            foreach (var dtoProduct in orderDto.Products)
            {
                var product = _mapper.Map<Product>(dtoProduct);
                products.Add(product);
                await _unitOfWork.Products.AddAsync(product);
            }

            await _unitOfWork.SaveChangesAsync();

            foreach (var product in products)
            {
                var orderProduct = new Order_Product
                {
                    OrderId = order.Id,
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
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _unitOfWork.Orders.DeleteAsync(orderId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AssignOrderToDelivery(int deliveryId, int orderId)
        {
            var delivery = await _unitOfWork.Delivery.GetByIdAsync(deliveryId);
            if (delivery == null) return;

            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return;

            order.DeliveryId = deliveryId;
            order.orderStatus = OrderStatus.Shipped;

            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order != null)
            {
                order.orderStatus = status;
                await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<PaginatedOrderDTO> GetPaginatedAsync(int page, int pageSize)
        {
            var result = await _unitOfWork.Orders.GetPaginatedAsync(page, pageSize);

            return new PaginatedOrderDTO
            {
                TotalRecords = result.TotalRecords,
                TotalPages = result.TotalPages,
                Orders = _mapper.Map<List<ReadOrderDTO>>(result.Data)
            };
        }

        public async Task<List<ReadOrderDTO>> GetOrderByMerchantId(int merchantId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByMerchantIdAsync(merchantId);
            return _mapper.Map<List<ReadOrderDTO>>(orders);
        }

        public async Task<List<ReadOrderDTO>> GetOrderbyDeliveryId(int deliveryId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByDeliveryIdAsync(deliveryId);
            return _mapper.Map<List<ReadOrderDTO>>(orders);
        }
    }
}
