using Application_CampFinalProject.Dtos.Role;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQuery:IRequest<GetAllRoleDTO>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;

        public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, GetAllRoleDTO>
        {
            private readonly IRoleService _roleService;

            public GetAllRoleQueryHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<GetAllRoleDTO> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
            {
                var (datas, count) = _roleService.GetAllRoles(request.Page, request.Size);
                return new()
                {
                    Datas = datas,
                    TotalCount = count
                };
            }
        }
    }
}
