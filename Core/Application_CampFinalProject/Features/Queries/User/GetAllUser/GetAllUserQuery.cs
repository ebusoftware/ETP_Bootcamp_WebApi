using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Queries.User.GetAllUser
{
    public class GetAllUserQuery:IRequest<GetAllUserDTO>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserDTO>
        {
            private readonly IUserService _userService;

            public GetAllUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<GetAllUserDTO> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var users = await _userService.GetAllUsersAsync(request.Page, request.Size);
                return new()
                {
                    Users = users,
                    TotalUsersCount = _userService.TotalUsersCount
                };
            }
        }

    }
}
