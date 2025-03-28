<<<<<<< HEAD
﻿using AutoMapper;
using Shipping.BL.DTOs.VillageDelivery;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
=======

﻿using System.Collections.Generic;
>>>>>>> master
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.VillageDelivery;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class VillageDeliveryService
    {
<<<<<<< HEAD

        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public VillageDeliveryService(IMapper mapper, UnitOfWork unitOfWork)
=======
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VillageDeliveryService(IMapper mapper, IUnitOfWork unitOfWork)
>>>>>>> master
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

<<<<<<< HEAD
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
=======
        public async Task<List<ReadVillageDTO>> GetAllAsync()
        {
            var deliveries = await _unitOfWork.VillageDelivery.GetAllAsync();
            return _mapper.Map<List<ReadVillageDTO>>(deliveries);
        }

        public async Task<ReadVillageDTO?> GetByIdAsync(int id)
        {
            var delivery = await _unitOfWork.VillageDelivery.GetByIdAsync(id);
            return delivery != null ? _mapper.Map<ReadVillageDTO>(delivery) : null;
        }

        public async Task AddAsync(AddVillageDTO deliveryDto)
        {
            var delivery = _mapper.Map<VillageDelivery>(deliveryDto);
            await _unitOfWork.VillageDelivery.AddAsync(delivery);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AddVillageDTO deliveryDto)
        {
            var existingDelivery = await _unitOfWork.VillageDelivery.GetByIdAsync(id);
            if (existingDelivery == null) return;

            _mapper.Map(deliveryDto, existingDelivery);
            await _unitOfWork.VillageDelivery.UpdateAsync(existingDelivery);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var delivery = await _unitOfWork.VillageDelivery.GetByIdAsync(id);
            if (delivery == null) return;

            delivery.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
>>>>>>> master
        }
    }
}
