﻿using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Features;
using Domain_CampFinalProject.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Services
{
    public interface IUserService
    {
        Task<CreateUserDTO> CreateAsync(CreateUserCommand model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
