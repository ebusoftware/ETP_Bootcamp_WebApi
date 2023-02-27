using Application_CampFinalProject;
using Application_CampFinalProject.Dtos.RefreshTokenDTO;
using Application_CampFinalProject.Features;
using Application_CampFinalProject.Features.Commands.User.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            TokenUserDTO response = await Mediator.Send(loginUserCommand);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommand refreshTokenLoginCommand)
        {
            RefreshTokenDTO response = await Mediator.Send(refreshTokenLoginCommand);
            return Ok(response);
        }
    }
}
