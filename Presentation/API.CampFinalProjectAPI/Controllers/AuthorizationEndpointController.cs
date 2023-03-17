using Application_CampFinalProject.Dtos.AuthorizationEndpoint;
using Application_CampFinalProject.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using Application_CampFinalProject.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQuery getRolesToEndpointQuery)
        {
            GetRolesToEnpointDTO response = await Mediator.Send(getRolesToEndpointQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommand assignRoleEndpointCommand)
        {
            assignRoleEndpointCommand.Type = typeof(Program);
            AssignRoleEndpointDTO response = await Mediator.Send(assignRoleEndpointCommand);
            return Ok(response);
        }
    }
}
