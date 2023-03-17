using Application_CampFinalProject.Dtos.AuthorizationEndpoint;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint
{
    public class GetRolesToEndpointQuery:IRequest<GetRolesToEnpointDTO>
    {
        public string Code { get; set; }
        public string Menu { get; set; }

        public class GetRolesToEndpointCommandHandler : IRequestHandler<GetRolesToEndpointQuery, GetRolesToEnpointDTO>
        {
            private readonly IAuthorizationEndpointService _authorizationEndpointService;

            public GetRolesToEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
            {
                _authorizationEndpointService = authorizationEndpointService;
            }

            public async Task<GetRolesToEnpointDTO> Handle(GetRolesToEndpointQuery request, CancellationToken cancellationToken)
            {
                var datas = await _authorizationEndpointService.GetRolesToEndpointAsync(request.Code, request.Menu);
                return new()
                {
                    Roles = datas
                };
            }
        }
    }
}
