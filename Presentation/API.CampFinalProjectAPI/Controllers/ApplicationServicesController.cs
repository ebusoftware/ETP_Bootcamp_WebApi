using Application_CampFinalProject.CustomAttribute;
using Application_CampFinalProject.Enums;
using Application_CampFinalProject.Services.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ApplicationServicesController : BaseController
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [AuthorizeDefinition(ActionType =ActionType.Reading,Definition ="Get Authorize Definiton Endpoints",Menu ="Application Services")]
        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));//program.cs nin bulunduğu katmanda devam et
            return Ok(datas);
        }
    }
}
