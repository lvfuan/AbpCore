using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCore.Authorization.Accounts.Dto;

namespace AbpCore.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
