using Microsoft.AspNetCore.Antiforgery;
using AbpCore.Controllers;

namespace AbpCore.Web.Host.Controllers
{
    public class AntiForgeryController : AbpCoreControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
