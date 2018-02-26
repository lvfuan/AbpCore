using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpCore.Configuration.Dto;

namespace AbpCore.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpCoreAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
