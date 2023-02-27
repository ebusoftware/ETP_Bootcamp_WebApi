using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Features;
using Application_CampFinalProject.Features.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand) 
        {
            CreateUserDTO response = await Mediator.Send(createUserCommand);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand deleteUserCommand)
        {
            DeleteUserDTO response = await Mediator.Send(deleteUserCommand);
            return Ok(response);
        }
    }
}
