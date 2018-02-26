using System.Threading.Tasks;
using AbpCore.Configuration.Dto;

namespace AbpCore.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
