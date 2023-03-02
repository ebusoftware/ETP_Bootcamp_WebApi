using Application_CampFinalProject.Consts;
using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.Brand;
using Application_CampFinalProject.Enums;
using Application_CampFinalProject.Features;
using Application_CampFinalProject.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class BrandController : BaseController
    {
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Reading, Definition = "Get All Brands")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandQuery getAllBrandQuery)
        {

            List<GetAllBrandDTO> resultModel = await Mediator.Send(getAllBrandQuery);
            return Ok(resultModel);

        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Writing, Definition = "Add to Brand")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommandRequest)
        {

            CreateBrandDTO result = await Mediator.Send(createBrandCommandRequest);
            return Created("", result);

        }
        [HttpDelete]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Deleting, Definition = "Remove Brand")]

        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            DeleteBrandDTO result = await Mediator.Send(deleteBrandCommand);
            return Ok(result);
        }
        [HttpPut]

        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Updating, Definition = "Update Brand")]

        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand) 
        {
            UpdateBrandDTO result = await Mediator.Send(updateBrandCommand);
            return Ok(result);
        }

    }
}
