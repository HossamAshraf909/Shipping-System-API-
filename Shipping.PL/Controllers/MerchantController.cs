﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Merchant;
using Shipping.BL.Services.Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly MerchantService _merchantService;

        public MerchantController(MerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMerchant([FromBody] AddMerchantDTO merchantDTO)
        {
            if (merchantDTO == null)
            {
                return BadRequest("Invalid data.");
            }

            var result= await _merchantService.AddAsync(merchantDTO);
            if (!result.Success)
            {
                return BadRequest(new
                {
                    error = "Failed to create employee",
                    details = result.Errors
                });
            }
            return Ok(new
            {
                message = "Merchant added successfully",
                statusCode = 200
            });
        }

        [HttpGet]
  
        public async Task<ActionResult<List<ReadMerchantDTO>>> GetAllMerchants()
        {
            var merchants = await _merchantService.GetAllAsync();
            return Ok(merchants);
        }
    }

}
