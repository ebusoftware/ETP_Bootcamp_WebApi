using Application_CampFinalProject.Dtos.RefreshTokenDTO;
using Application_CampFinalProject.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features
{
    public class RefreshTokenLoginCommand:IRequest<RefreshTokenDTO>
    {
        public string RefreshToken { get; set; }

        public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommand, RefreshTokenDTO>
        {
            private readonly IAuthService _authService;
            public RefreshTokenLoginCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }
            public async Task<RefreshTokenDTO> Handle(RefreshTokenLoginCommand request, CancellationToken cancellationToken)
            {
                Dtos.TokenDTO.TokenDTO token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
                return new()
                {
                    Token = token
                };
            }
        }
    }
}
