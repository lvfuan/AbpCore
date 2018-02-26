using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCore.Sessions.Dto;

namespace AbpCore.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
