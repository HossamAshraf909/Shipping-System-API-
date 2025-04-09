using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Employee;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class EmployeeService
    {
        IMapper _map;
        IUnitOfWork unit;
        public EmployeeService(IUnitOfWork unit,IMapper _map)
        {
            this.unit = unit;
            this._map = _map;
        }

        public async Task<List<ReadEmployeeDTO>> GetAllAsync()
        {
            var Employees = await unit.Employee.GetAllAsync();
            return _map.Map<List<ReadEmployeeDTO>>(Employees);
        }


        public async Task AddEmployeeAsync(AddEmployeeDTO employeeDTO)
        {
            var Employee = _map.Map<Employee>(employeeDTO);
            await unit.Employee.AddAsync(Employee);
            await unit.SaveChangesAsync();
        }


        public async Task UpdateEmployeeAsync(int id,AddEmployeeDTO employeeDTO)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            if (Employee == null) return;

            _map.Map(employeeDTO, Employee);
            await unit.Employee.UpdateAsync(Employee);


        }

       

    }
}
