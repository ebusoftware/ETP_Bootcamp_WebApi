using Application_CampFinalProject.Consts;
using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ShoppingList;
using Application_CampFinalProject.Dtos.ShoppingListDTO;
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
    public class ShoppingListController : BaseController
    {
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingLists, ActionType = ActionType.Reading, Definition = "Get All Shooing Lists")]

        public async Task<IActionResult> GetAll([FromQuery] GetAllShoppingListQuery getAllShoppingListQuery)
        {
            List<GetAllShoppingListDTO> datas = await Mediator.Send(getAllShoppingListQuery);
            return Ok(datas);
        }
        [HttpGet("[action]/{UserId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingLists, ActionType = ActionType.Reading, Definition = "Get By UserId Shopping Lists")]

        public async Task<IActionResult> GetByUser([FromRoute] GetByUserShoppingListQuery getByUserShoppingListQuery)
        {
            List<GetByUserDTO> datas = await Mediator.Send(getByUserShoppingListQuery);
            return Ok(datas);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingLists, ActionType = ActionType.Writing, Definition = "Add to Shopping List")]

        public async Task<IActionResult> Add([FromBody] CreateShoppingListCommand createShoppingListCommand)
        {
            CreateShoppingListDTO result = await Mediator.Send(createShoppingListCommand);
            return Ok(result);
        }
        [HttpDelete]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingLists, ActionType = ActionType.Deleting, Definition = "Remove Shopping List")]
        public async Task<IActionResult> Delete([FromBody] DeleteShoppingListCommand deleteShoppingListCommand)
        {
            DeleteShoppingListDTO result = await Mediator.Send(deleteShoppingListCommand);
            return Ok(result);
        }
        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingLists, ActionType = ActionType.Updating, Definition = "Update Shoppin List")]
        public async Task<IActionResult> Update([FromBody] UpdateShoppingListCommand updateShoppingListCommand)
        {
            UpdateShoppingListDTO result = await Mediator.Send(updateShoppingListCommand);
            return Ok(result);
        }
    }
}
