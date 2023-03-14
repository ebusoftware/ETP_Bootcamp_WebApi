using Application_CampFinalProject.Dtos.Role;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommand:IRequest<CreateRolDTO>
    {
        public string Name { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRolDTO>
        {
            private readonly IRoleService _roleService;

            public CreateRoleCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<CreateRolDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var result = await _roleService.CreateRole(request.Name);
                return new()
                {
                    Succeeded = result
                };
            }
        }
    }
}
