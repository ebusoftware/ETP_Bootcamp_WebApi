using Domain_CampFinalProject.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Rules.User
{
    public class UserBusinessRules
    {
        readonly UserManager<AppUser> _userManager;

        public UserBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            AppUser result = await _userManager.FindByEmailAsync(email);
            if (result != null) throw new Exception("Mail adresiyle önceden kayıt olunmuş.");
        }
        public async Task UserShouldExistWhenRequested(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new Exception("Kullanıcı mevcut değil.");
        }
    }
}