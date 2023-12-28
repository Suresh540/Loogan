using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Controllers
{
    [Route("Language")]
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SetLanguage")]
        public IActionResult SetLanguage()
        {
            var returnUrl = Request.Form["returnurl"];
            var culture = Request.Form["culture"];
            HttpContext.Session.SetInt32("LanguageId", LanguageSelection.GetLanguageId(culture));
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }

    }
}
