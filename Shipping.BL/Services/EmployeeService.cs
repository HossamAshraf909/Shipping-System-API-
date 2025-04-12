using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Employee;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class EmployeeService
    {
        IMapper _map;
        IUnitOfWork unit;
        UserManager<ApplicationUser> userManager;
        public EmployeeService(IUnitOfWork unit,IMapper _map,UserManager<ApplicationUser> userManager)
        {
            this.unit = unit;
            this._map = _map;
            this.userManager = userManager;
        }

        public async Task<List<ReadEmployeeDTO>> GetAllAsync()
        {
            var Employees = await unit.Employee.GetAllAsync();
            return _map.Map<List<ReadEmployeeDTO>>(Employees);
        }
        public async Task<ReadEmployeeDTO?> GetByIdAsync(int id)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            return Employee != null ? _map.Map<ReadEmployeeDTO>(Employee) : null;
        }

        public async Task AddEmployeeAsync(AddEmployeeDTO employeeDTO)
        {

            var applicationUser = new ApplicationUser
            {
                UserName = employeeDTO.Name,
                Email = employeeDTO.Email,
                PasswordHash = employeeDTO.Password,
                Address = employeeDTO.address,

            };

            await userManager.CreateAsync(applicationUser,employeeDTO.Password);

           var result =  await userManager.AddToRoleAsync(applicationUser,employeeDTO.UserRole);

            var user = await userManager.FindByNameAsync(employeeDTO.Name);

            var Employee = new Employee
            {
                BranchId = employeeDTO.BranchId,
                PhoneNumber = employeeDTO.PhoneNumber,
                UserID = user.Id
            };

            await unit.Employee.AddAsync(Employee);
            await unit.SaveChangesAsync();
                
            
        }


        public async Task UpdateEmployeeAsync(int id,EditEmployeeDTO employeeDTO)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            if (Employee == null) return;
            var applicationUser = await userManager.FindByEmailAsync(employeeDTO.Email);
            applicationUser.UserName = employeeDTO.Name;
            applicationUser.Email = employeeDTO.Email;
            applicationUser.Address = employeeDTO.address;
            applicationUser.PasswordHash = employeeDTO.Password;
            await userManager.UpdateAsync(applicationUser);
            await userManager.AddToRoleAsync(applicationUser, employeeDTO.UserRole);


            Employee.BranchId = employeeDTO.BranchId;
            Employee.PhoneNumber = employeeDTO.PhoneNumber;

            await unit.Employee.UpdateAsync(Employee);

            await unit.SaveChangesAsync();
        }

       

    }
}
