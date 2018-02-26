using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace AbpCore.Web.Views
{
    public abstract class AbpCoreRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpCoreRazorPage()
        {
            LocalizationSourceName = AbpCoreConsts.LocalizationSourceName;
        }
    }
}
