using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Enums;
using Application_CampFinalProject.Features;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Commands.User.AssignRoleToUser;
using Application_CampFinalProject.Features.Queries.User.GetAllUser;
using Application_CampFinalProject.Features.Queries.User.GetRolesToUser;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQuery getAllUserQuery)
        {
            GetAllUserDTO response = await Mediator.Send(getAllUserQuery);
            return Ok(response);
        }

        [HttpGet("get-roles-to-user/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQuery getRolesToUserQuery)
        {
            GetRolesToUserQueryDTO response = await Mediator.Send(getRolesToUserQuery);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommand assignRoleToUserCommand)
        {
            AssignRoleToUserDTO response = await Mediator.Send(assignRoleToUserCommand);
            return Ok(response);
        }
    }
}
