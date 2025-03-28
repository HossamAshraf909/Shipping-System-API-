using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.ShippingType;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class ShippingTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadShippingTypeDTO>> GetAllAsync()
        {
            var shippingTypes = await _unitOfWork.ShippingTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadShippingTypeDTO>>(shippingTypes);
        }

        public async Task AddAsync(AddShippingTypeDTO shippingTypeDTO)
        {
            var shippingType = _mapper.Map<ShippingType>(shippingTypeDTO);
            await _unitOfWork.ShippingTypes.AddAsync(shippingType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(AddShippingTypeDTO shippingTypeDTO)
        {
            var shippingType = _mapper.Map<ShippingType>(shippingTypeDTO);
            await _unitOfWork.ShippingTypes.UpdateAsync(shippingType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ShippingTypes.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
