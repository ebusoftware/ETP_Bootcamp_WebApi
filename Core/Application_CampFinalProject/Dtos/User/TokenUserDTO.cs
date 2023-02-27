using Application_CampFinalProject.Dtos.TokenDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject
{
    public class TokenUserDTO
    {
        public static implicit operator TokenUserDTO(TokenDTO v)
        {
            throw new NotImplementedException();
        }
    }
    public class LoginUserSuccessCommandResponse : TokenUserDTO
    {
        public TokenDTO Token { get; set; }
    }
    public class LoginUserErrorCommandResponse : TokenUserDTO
    {
        public string Message { get; set; }
    }
}
