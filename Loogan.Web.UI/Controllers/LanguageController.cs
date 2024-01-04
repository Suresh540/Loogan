using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
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
        [Route("SetJsonLanguage")]
        [AllowAnonymous]
        public IActionResult SetJsonLanguage(string culture)
        {
            HttpContext.Session.SetInt32("LanguageId", LanguageSelection.GetLanguageId(culture));
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return Json(new { value = "success" });
        }
    }
}
