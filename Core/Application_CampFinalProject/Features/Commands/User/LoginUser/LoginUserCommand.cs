using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands.User.LoginUser
{
    public class LoginUserCommand:IRequest<TokenUserDTO>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenUserDTO>
        {
            private readonly IAuthService _authService;

            public LoginUserCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<TokenUserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 1500);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }
        }
    }
}
