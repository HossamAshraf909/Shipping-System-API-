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
        public IActionResult GetAllBranchs()
        {
            return Ok(branchService.GetAll());
        }



        [HttpGet]
        [Route("api/branchSearch/{searchWord}")]
        public IActionResult SearchForBranch(string searchWord)
        {
            return Ok(branchService.Search(searchWord));
        }



        [HttpPost]
        public IActionResult AddBranch(AddBrachDTO branch)
        {
            if (branch == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            branchService.Add(branch);
            return Ok();
        }



        [HttpPut]
        public IActionResult UpdateBranch(AddBrachDTO branch)
        {
            if (branch == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            branchService.Update(branch);
            return Ok();

        }




        [HttpDelete]
        public IActionResult DeleteBranch(int id)
        {
            ReadBranchDTO branch = branchService.GetById(id);
            if (branch == null) return BadRequest();
            branchService.Delete(id);
            return Ok();

        }


        // Entities


    }
}
