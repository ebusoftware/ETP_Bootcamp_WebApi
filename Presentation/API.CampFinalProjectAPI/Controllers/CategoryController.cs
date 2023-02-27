using Application_CampFinalProject.Dtos.Category;
using Application_CampFinalProject.Features.Commands;
using Application_CampFinalProject.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery getAllCategoryQuery)
        {
            List<GetAllCategoryDTO> result = await Mediator.Send(getAllCategoryQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDTO result = await Mediator.Send(createCategoryCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeleteCategoryDTO result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand  updateCategoryCommand)
        {
            UpdateCategoryDTO result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }
    }
}
