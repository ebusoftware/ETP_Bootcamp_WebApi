using Application_CampFinalProject.Consts;
using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ProductImageFile;
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
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class ProductController : BaseController
    {
        [HttpGet]

        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products,ActionType = ActionType.Reading,Definition ="Get Products")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery getAllProductQuery)
        {
            List<GetAllProductDTO> datas = await Mediator.Send(getAllProductQuery);
            return Ok(datas);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Add to Product")]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreateProductDTO data = await Mediator.Send(createProductCommand);
            return Ok(data);
        }

        [HttpDelete]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
        {
            DeleteProductDTO data = await Mediator.Send(deleteProductCommand);
            return Ok(data);
        }
        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            UpdateProductDTO data = await Mediator.Send(updateProductCommand);
            return Ok(data);
        }
        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product image")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommand uploadProductImageCommand)
        {
            uploadProductImageCommand.Files = Request.Form.Files;
            UploadImageFileDTO response = await Mediator.Send(uploadProductImageCommand);
            return Ok(response);
        }
        [HttpDelete("[action]/{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product image")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommand removeProductImageCommand, [FromQuery] int imageId)
        {
            removeProductImageCommand.ImageId = imageId;
            RemoveImageFileDTO response = await Mediator.Send(removeProductImageCommand);
            return Ok();
        }
        [HttpGet("[action]")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Change Show Case Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommand changeShowcaseImageCommand)
        {
            ShowCaseImageDTO response = await Mediator.Send(changeShowcaseImageCommand);
            return Ok(response);
        }
    }
}
