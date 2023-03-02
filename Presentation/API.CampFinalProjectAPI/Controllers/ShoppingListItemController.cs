using Application_CampFinalProject.Consts;
using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.ShoppingListItem;
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
    
    public class ShoppingListItemController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllShoppingListItemQuery getAllShoppingListItemQuery)
        {
            List<GetAllShoppingListItemDTO> datas = await Mediator.Send(getAllShoppingListItemQuery);
            return Ok(datas);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingListItems, ActionType = ActionType.Writing, Definition = "Add to Shopping List Item")]
        public async Task<IActionResult> Add([FromBody] CreateShoppingListItemCommand createShoppingListItemCommand)
        {
            CreateShoppingListItemDTO data = await Mediator.Send(createShoppingListItemCommand);
            return Ok(data);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingListItems, ActionType = ActionType.Updating, Definition = "Update Shopping List Item")]
        public async Task<IActionResult> Update([FromBody] UpdateShoppingListItemCommand updateShoppingListItemCommand)
        {
            UpdateShoppingListItemDTO data = await Mediator.Send(updateShoppingListItemCommand);
            return Ok(data);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingListItems, ActionType = ActionType.Deleting, Definition = "Delete Shopping List Item")]
        public async Task<IActionResult> Delete([FromBody] DeleteShoppingListItemCommand deleteShoppingListItemCommand)
        {
            DeleteShoppingListItemDTO data = await Mediator.Send(deleteShoppingListItemCommand);
            return Ok(data);
        }
    }
}
