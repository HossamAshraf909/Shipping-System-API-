using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Weight;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class WeightPriceService
    {
        UnitOfWork unit;
        IMapper map;
        public WeightPriceService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
            
        }
        public List<ReadWeightDTO> GetAll()
        {
            List<WeightPrice> weightPrices = unit.WeightPriceRepo.GetAll().ToList();

            List<ReadWeightDTO> weightPricesDTO = map.Map<List<ReadWeightDTO>>(weightPrices);
            return weightPricesDTO;
        }



        public ReadWeightDTO GetById(int id)
        {
            WeightPrice weightPrice = unit.WeightPriceRepo.GetById(id);
            ReadWeightDTO weightPriceDTO = map.Map<ReadWeightDTO>(weightPrice);
            return weightPriceDTO;
        }


        public void Add(AddWeightDTO weighttDTO)
        {
            WeightPrice weightPrice = map.Map<WeightPrice>(weighttDTO);
            unit.WeightPriceRepo.Add(weightPrice);
            unit.Save();
        }


        public void Update (AddWeightDTO weighttDTO)
        {
            WeightPrice weightPrice = map.Map<WeightPrice>(weighttDTO);
            unit.WeightPriceRepo.Update(weightPrice);
            unit.Save();
        }

        public void Delete(int id)
        {
            WeightPrice weightPrice = unit.WeightPriceRepo.GetById(id);
            weightPrice.IsDeleted = true;
            unit.Save();
        }

    }
}
