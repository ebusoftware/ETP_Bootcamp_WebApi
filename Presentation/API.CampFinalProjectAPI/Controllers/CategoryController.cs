using Application_CampFinalProject.Consts;
using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.Category;
using Application_CampFinalProject.Enums;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class CategoryController : BaseController
    {
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Reading, Definition = "Get All Categories")]

        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery getAllCategoryQuery)
        {
            List<GetAllCategoryDTO> result = await Mediator.Send(getAllCategoryQuery);
            return Ok(result);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Writing, Definition = "Add to Category")]

        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDTO result = await Mediator.Send(createCategoryCommand);
            return Ok(result);
        }
        [HttpDelete]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Deleting, Definition = "Remove Category")]

        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeleteCategoryDTO result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Updating, Definition = "Update Category")]

        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand  updateCategoryCommand)
        {
            UpdateCategoryDTO result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }
    }
}
