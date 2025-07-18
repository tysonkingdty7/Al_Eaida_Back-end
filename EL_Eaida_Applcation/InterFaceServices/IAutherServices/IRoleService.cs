using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.UserDTo;

namespace EL_Eaida_Applcation.InterFaceServices.IRoleServices
{
    public interface IRoleService
    {
        Task<bool> AddRoleAsync(AddRoleDto dto);
        Task<RoleResultDto> GetUserRolesAsync(string userId);
        Task<bool> RemoveRoleAsync(string userId, string role);
    }
}
