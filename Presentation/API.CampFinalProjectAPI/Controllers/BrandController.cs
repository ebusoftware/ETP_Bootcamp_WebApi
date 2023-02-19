using Application_CampFinalProject.Dtos.Brand;
using Application_CampFinalProject.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommandRequest)
        {

            CreateBrandDTO result = await Mediator.Send(createBrandCommandRequest);
            return Created("", result);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            DeleteBrandDTO result = await Mediator.Send(deleteBrandCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand) 
        {
            UpdateBrandDTO result = await Mediator.Send(updateBrandCommand);
            return Ok(result);
        }
    }
}
