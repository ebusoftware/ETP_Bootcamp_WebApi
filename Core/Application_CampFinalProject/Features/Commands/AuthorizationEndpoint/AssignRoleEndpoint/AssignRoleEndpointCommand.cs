using Application_CampFinalProject.Dtos.AuthorizationEndpoint;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommand : IRequest<AssignRoleEndpointDTO>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type? Type { get; set; }

        public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommand, AssignRoleEndpointDTO>
        {
            private readonly IAuthorizationEndpointService _authorizationEndpointService;

            public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
            {
                _authorizationEndpointService = authorizationEndpointService;
            }

            public async Task<AssignRoleEndpointDTO> Handle(AssignRoleEndpointCommand request, CancellationToken cancellationToken)
            {
                await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
                return new()
                {

                };
            }
        }
    }
}
