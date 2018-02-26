using System.Collections.Generic;
using AbpCore.Roles.Dto;
using AbpCore.Users.Dto;

namespace AbpCore.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
