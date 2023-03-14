using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.Configuration;
using Application_CampFinalProject.Dtos.Role;
using Application_CampFinalProject.Enums;
using Application_CampFinalProject.Features.Commands.Role.CreateRole;
using Application_CampFinalProject.Features.Commands.Role.DeleteRole;
using Application_CampFinalProject.Features.Commands.Role.UpdateRole;
using Application_CampFinalProject.Features.Queries.Role.GetAllRole;
using Application_CampFinalProject.Features.Queries.Role.GetByIdRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RoleController : BaseController
    {
        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRoleQuery getAllRoleQuery)
        {
            GetAllRoleDTO response = await Mediator.Send(getAllRoleQuery);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromRoute] GetByIdRoleQuery getByIdRoleQuery)
        {
            GetByIdRoleDTO response = await Mediator.Send(getByIdRoleQuery);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand createRoleCommand)
        {
            CreateRolDTO response = await Mediator.Send(createRoleCommand);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommand updateRoleCommand)
        {
            UpdateRoleDTO response = await Mediator.Send(updateRoleCommand);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRolCommand deleteRolCommand)
        {
            DeleteRolDTO response = await Mediator.Send(deleteRolCommand);
            return Ok(response);
        }
    }
}
