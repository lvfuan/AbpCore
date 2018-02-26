using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpCore.Web.Views
{
    public abstract class AbpCoreViewComponent : AbpViewComponent
    {
        protected AbpCoreViewComponent()
        {
            LocalizationSourceName = AbpCoreConsts.LocalizationSourceName;
        }
    }
}
