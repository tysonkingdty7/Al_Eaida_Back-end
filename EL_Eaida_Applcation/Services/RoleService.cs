using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using EL_Eaida_Applcation.DTO.UserDTo;
using EL_Eaida_Applcation.InterFaceServices.IRoleServices;
using Microsoft.AspNetCore.Identity;

namespace EL_Eaida_Applcation.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddRoleAsync(AddRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return false;
            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                var role = await _roleManager.CreateAsync(new IdentityRole(dto.Role));
                if (!role.Succeeded)
                {
                    return false;
                }
            }
            var result = await _userManager.AddToRoleAsync(user, dto.Role);
            return result.Succeeded;
        }




        public async Task<RoleResultDto> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            return new RoleResultDto
            {
                UserId = userId,
                Roles = new List<string>(roles)
            };

        }

        public async Task<bool> RemoveRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }
    }
    }
