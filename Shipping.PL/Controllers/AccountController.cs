using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Auth.Account;
using Shipping.BL.Services.Imodel;
using Shipping.DAL.Entities.Identity;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenGeneration _tokenGeneration;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager , ITokenGeneration tokenGeneration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGeneration = tokenGeneration;
        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return Unauthorized(new ApiResponse<string>(
                    statusCode: 401,
                    message: "User not found",
                    data: null
                ));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse<string>(
                    statusCode: 401,
                    message: "Invalid password",
                    data: null
                ));
            }

            return Ok(new ApiResponse<UserDTO>(
                statusCode: 200,
                message: "Login success",
                data: new UserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = await _tokenGeneration.CreateTokenAsync(user, _userManager),
                }));
        }

    }
}