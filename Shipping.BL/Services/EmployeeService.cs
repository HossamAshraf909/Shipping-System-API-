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
        private readonly RoleManager<ApplicationRole> roleManager;

        public EmployeeService(IUnitOfWork unit, IMapper _map, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.unit = unit;
            this._map = _map;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<List<ReadEmployeeDTO>> GetAllAsync()
        {
            var Employees = await unit.Employee.GetAllAsync();
            var EmployeeList = new List<ReadEmployeeDTO>();
            foreach (var employee in Employees)
            {
                var user = await userManager.FindByIdAsync(employee.UserID);
                var roles = await userManager.GetRolesAsync(user);
                var role = roles.First();
                var ReadEmployeeDTO = new ReadEmployeeDTO
                {
                    id = employee.ID,
                    Name = user.UserName,
                    Email = user.Email,
                    UserRole = role,
                    PhoneNumber = employee.PhoneNumber,
                    Branch = (await unit.Branches.GetByIdAsync(employee.BranchId)).Name
                };
                EmployeeList.Add(ReadEmployeeDTO);

            }
            return EmployeeList;
        }
        public async Task<ReadEmployeeDTO?> GetByIdAsync(int id)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            var user = await userManager.FindByIdAsync(Employee.UserID);
            var roles = await userManager.GetRolesAsync(user);
            var role = roles.First();
            var ReadEmployeeDTO = new ReadEmployeeDTO
            {
                id = Employee.ID,
                Name = user.UserName,
                Email = user.Email,
                UserRole = role,
                PhoneNumber = Employee.PhoneNumber,
                Branch = (await unit.Branches.GetByIdAsync(Employee.BranchId)).Name
            };
            return ReadEmployeeDTO;
        }

        public async Task<bool> AddEmployeeAsync(AddEmployeeDTO employeeDTO)
        {

            var applicationUser = new ApplicationUser
            {
                UserName = employeeDTO.Name,
                Email = employeeDTO.Email,
                Address = employeeDTO.address,
            };

            var result = await userManager.CreateAsync(applicationUser, employeeDTO.Password);
            if (!result.Succeeded)
                return false;

            if (await roleManager.RoleExistsAsync("Employee"))
                await userManager.AddToRoleAsync(applicationUser,"Employee");


            var Employee = new Employee
            {
                BranchId = employeeDTO.BranchId,
                PhoneNumber = employeeDTO.PhoneNumber,
                UserID = applicationUser.Id
            };

            await unit.Employee.AddAsync(Employee);
            await unit.SaveChangesAsync();
            return true;
        }


        public async Task UpdateEmployeeAsync(int id, EditEmployeeDTO employeeDTO)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            if (Employee == null) return;
            var applicationUser = await userManager.FindByEmailAsync(employeeDTO.Email);
            applicationUser.UserName = employeeDTO.Name;
            applicationUser.Email = employeeDTO.Email;
            applicationUser.Address = employeeDTO.address;
            applicationUser.PasswordHash = employeeDTO.Password;
            await userManager.UpdateAsync(applicationUser);

            var result = await roleManager.RoleExistsAsync(employeeDTO.UserRole);
            if (result)
            {
                var user = await userManager.FindByIdAsync(applicationUser.Id);
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count > 0)
                {
                    await userManager.RemoveFromRoleAsync(user, roles[0]);
                }
                await userManager.AddToRoleAsync(user, employeeDTO.UserRole);
            }

            Employee.BranchId = employeeDTO.BranchId;
            Employee.PhoneNumber = employeeDTO.PhoneNumber;

            await unit.Employee.UpdateAsync(Employee);

            await unit.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var Employee = await unit.Employee.GetByIdAsync(id);
            if (Employee == null) return;
            var user = await userManager.FindByIdAsync(Employee.UserID);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
            await unit.Employee.DeleteAsync(id);
            await unit.SaveChangesAsync();
        }
    }
}
