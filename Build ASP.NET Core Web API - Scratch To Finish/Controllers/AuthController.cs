using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Auth;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Auth.Token;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepositoriesToken repositoriesToken;

        public AuthController(UserManager<IdentityUser> userManager, IRepositoriesToken repositoriesToken)
        {
            this.userManager = userManager;
            this.repositoriesToken = repositoriesToken;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Reqister([FromBody] AuthRegisterRequrstDto registerRequrstDto)
        {
            var error = "";
            try
            {
                var IdentityUser = new IdentityUser
                {
                    UserName = registerRequrstDto.UserName,
                    Email = registerRequrstDto.UserName,
                };
                var IdentityResult = await userManager.CreateAsync(IdentityUser, registerRequrstDto.Password);

                if (IdentityResult.Succeeded)
                {
                    if (registerRequrstDto.Roles != null && registerRequrstDto.Roles.Any())
                    {
                        IdentityResult = await userManager.AddToRolesAsync(IdentityUser, registerRequrstDto.Roles);
                        if (IdentityResult.Succeeded)
                        {
                            return Ok("Done Create Account");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return BadRequest(error);

        }




        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginDto authLoginDto)
        {
            var user = await userManager.FindByEmailAsync(authLoginDto.UserName);

            if (user != null)
            {
                var Checkpassword = await userManager.CheckPasswordAsync(user, authLoginDto.Password);
                if (Checkpassword)
                {
                    var role = await userManager.GetRolesAsync(user);
                    if (role != null)
                    {
                        var jwtToken = repositoriesToken.CreateToken(user , role.ToList());

                        var reaponae = new LoginResponseTokenDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(reaponae);
                    }


                    return Ok();
                }
            }

            return BadRequest("UserName Or Pass Not coreact");
        }
    }
}
