using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ProductImageFile;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Queries;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommand uploadProductImageCommand)
        {
            uploadProductImageCommand.Files = Request.Form.Files;
            UploadImageFileDTO response = await Mediator.Send(uploadProductImageCommand);
            return Ok(response);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommand removeProductImageCommand, [FromQuery] int imageId)
        {
            //Burada RemoveProductImageCommandRequest sınıfı içerisindeki ImageId property'sini de 'FromQuery' attribute'u ile işaretleyebilirdik!

            removeProductImageCommand.ImageId = imageId;
            RemoveImageFileDTO response = await Mediator.Send(removeProductImageCommand);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommand changeShowcaseImageCommand)
        {
            ShowCaseImageDTO response = await Mediator.Send(changeShowcaseImageCommand);
            return Ok(response);
        }
    }
}
