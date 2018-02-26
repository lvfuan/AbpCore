using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCore.Controllers;

namespace AbpCore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AbpCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
