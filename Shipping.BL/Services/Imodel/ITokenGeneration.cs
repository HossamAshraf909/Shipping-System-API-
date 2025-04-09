using Microsoft.AspNetCore.Identity;
using Shipping.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services.Imodel
{
    public interface ITokenGeneration
    {


        public Task<string> CreateTokenAsync(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager);
    }
}
