using Application_CampFinalProject.Dtos.TokenDTO;
using Domain_CampFinalProject.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
