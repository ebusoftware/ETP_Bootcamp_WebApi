using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.CampFinalProjectAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        //Butun controller icin BaseController insa ettik. Bu controller'ı referans alan diger controllerlar artik bunu kullancak.
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //Mediator varsa onu donder yoksa IOC den Mediator 'ı cek.
        private IMediator? _mediator;


    }
}
