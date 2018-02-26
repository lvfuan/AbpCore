using Abp.Authorization;
using AbpCore.Authorization.Roles;
using AbpCore.Authorization.Users;

namespace AbpCore.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
