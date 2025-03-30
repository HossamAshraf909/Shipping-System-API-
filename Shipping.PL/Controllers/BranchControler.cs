using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.Services;
using Shipping.DAL.Entities;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchControler : ControllerBase
    {
        BranchService branchService;
        public BranchControler(BranchService branchService)
        {
            this.branchService = branchService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBranchs()
        {
            return Ok(await branchService.GetAllAsync());
        }



        [HttpGet]
        [Route("api/branchSearch/{searchWord}")]
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
            return Ok();
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBranchAsync(int id,AddBrachDTO branch)
        {
            if (branch == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            await branchService.UpdateAsync(id,branch);
            return Ok();

        }




        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            ReadBranchDTO branch = await branchService.GetByIdAsync(id);
            if (branch == null) return BadRequest();
            await branchService.DeleteAsync(id);
            return Ok();

        }


    }
}
