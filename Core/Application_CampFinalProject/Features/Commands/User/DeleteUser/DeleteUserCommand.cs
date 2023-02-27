using Application_CampFinalProject.Dtos.User;
using AutoMapper;
using Domain_CampFinalProject.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class DeleteUserCommand:IRequest<DeleteUserDTO>
    {
        public string Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserDTO>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<DeleteUserDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                AppUser mappedUser = _mapper.Map<AppUser>(request);
                AppUser deletedUser = await _userManager.FindByIdAsync(mappedUser.Id);
                DeleteUserDTO deleteUserDTO = _mapper.Map<DeleteUserDTO>(deletedUser);
                return deleteUserDTO;
            }
        }
    }
}
