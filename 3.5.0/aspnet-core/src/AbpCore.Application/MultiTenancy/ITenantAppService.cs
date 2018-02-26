using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCore.MultiTenancy.Dto;

namespace AbpCore.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
