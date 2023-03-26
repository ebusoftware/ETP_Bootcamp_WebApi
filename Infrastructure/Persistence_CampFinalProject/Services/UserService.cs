using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Exceptions;
using Application_CampFinalProject.Features;
using Application_CampFinalProject.Services;
using Domain_CampFinalProject.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_CampFinalProject.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserDTO> CreateAsync(CreateUserCommand model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);
            CreateUserDTO response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UserException("Kullanıcı adı veya şifre yanlış.");
        }
        public async Task<List<ListUserDTO>> GetAllUsersAsync(int page, int size)
        {
            var users = await _userManager.Users
                  .Skip(page * size)
                  .Take(size)
                  .ToListAsync();

            return users.Select(user => new ListUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName

            }).ToList();
        }

        public int TotalUsersCount => _userManager.Users.Count();

        public async Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                await _userManager.AddToRolesAsync(user, roles);
            }
        }
        public async Task<string[]> GetRolesToUserAsync(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }
    }
}
