using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features
{
    public class CreateUserCommand:IRequest<CreateUserDTO>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDTO>
        {
            private readonly IUserService _userService;

            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                CreateUserDTO response = await _userService.CreateAsync(new()
                {
                    Email = request.Email,
                    NameSurname = request.NameSurname,
                    Password = request.Password,
                    PasswordConfirm = request.PasswordConfirm,
                    Username = request.Username,
                });

                return new()
                {
                    Message = response.Message,
                    Succeeded = response.Succeeded,
                };
            }
        }
    }
}
