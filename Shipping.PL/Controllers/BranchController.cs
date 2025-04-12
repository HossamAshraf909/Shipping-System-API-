using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.Services;
using Shipping.DAL.Entities;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        BranchService branchService;
        public BranchController(BranchService branchService)
        {
            this.branchService = branchService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBranchs()
        {
            return Ok(await branchService.GetAllAsync());
        }



        [HttpGet("{searchWord:alpha}")]
     
        public async Task<IActionResult> SearchForBranchAsync(string searchWord)
        {
            return Ok(await branchService.SearchAsync(searchWord));
        }



        [HttpPost]
        public async Task<IActionResult> AddBranch(AddBrachDTO branch)
        {
            if (branch == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
           await branchService.AddAsync(branch);
            return Ok(new
            {
                message = "Branch added successfully",
                statusCode = 200
            });
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBranchAsync(int id,AddBrachDTO branch)
        {
            if (branch == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            await branchService.UpdateAsync(id,branch);
            return Ok(new
            {
                message = "Branch updated successfully",
                statusCode = 200
            });

        }




        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            ReadBranchDTO branch = await branchService.GetByIdAsync(id);
            if (branch == null) return BadRequest();
            await branchService.DeleteAsync(id);
            return Ok(new
            {
                message = "Branch deleted successfully",
                statusCode = 200
            });

        }


    }
}
