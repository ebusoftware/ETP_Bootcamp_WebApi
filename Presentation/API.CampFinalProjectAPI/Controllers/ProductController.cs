using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery getAllProductQuery)
        {
            List<GetAllProductDTO> datas = await Mediator.Send(getAllProductQuery);
            return Ok(datas);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreateProductDTO data = await Mediator.Send(createProductCommand);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
        {
            DeleteProductDTO data = await Mediator.Send(deleteProductCommand);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            UpdateProductDTO data = await Mediator.Send(updateProductCommand);
            return Ok(data);
        }
    }
}
