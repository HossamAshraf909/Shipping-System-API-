using AutoMapper;
using Shipping.BL.DTOs.VillageDelivery;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services
{
    public class VillageDeliveryService
    {

        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public VillageDeliveryService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<ReadVillageDTO> GetAll()
        {
            var deliveries = _unitOfWork.villageDelivery.GetAll().ToList();
            return _mapper.Map<List<ReadVillageDTO>>(deliveries);
        }

        public ReadVillageDTO GetById(int id)
        {
            var delivery = _unitOfWork.villageDelivery.GetById(id);
            return _mapper.Map<ReadVillageDTO>(delivery);
        }

        public void Add(AddVillageDTO deliveryDto)
        {
            var delivery = _mapper.Map<VillageDelivery>(deliveryDto);
            _unitOfWork.villageDelivery.Add(delivery);
            _unitOfWork.Save();
        }

        public void Update(AddVillageDTO deliveryDto)
        {
            var delivery = _mapper.Map<VillageDelivery>(deliveryDto);
            _unitOfWork.villageDelivery.Update(delivery);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var delivery = _unitOfWork.villageDelivery.GetById(id);
            if (delivery != null)
            {
                delivery.IsDeleted = true;
                _unitOfWork.Save();
            }
        }
    }
}
