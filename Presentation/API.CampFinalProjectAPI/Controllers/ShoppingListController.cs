using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ShoppingList;
using Application_CampFinalProject.Dtos.ShoppingListDTO;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllShoppingListQuery getAllShoppingListQuery)
        {
            List<GetAllShoppingListDTO> datas = await Mediator.Send(getAllShoppingListQuery);
            return Ok(datas);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShoppingListCommand createShoppingListCommand)
        {
            CreateShoppingListDTO result = await Mediator.Send(createShoppingListCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteShoppingListCommand deleteShoppingListCommand)
        {
            DeleteShoppingListDTO result = await Mediator.Send(deleteShoppingListCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShoppingListCommand updateShoppingListCommand)
        {
            UpdateShoppingListDTO result = await Mediator.Send(updateShoppingListCommand);
            return Ok(result);
        }
    }
}
