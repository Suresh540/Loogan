using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [AllowAnonymous]
    [Route("Account")]
    public class AccountController : Controller
    {
        [Route("Login")]
        public IActionResult Login()
        {
            return RedirectToPage("/Index");
        }
    }
}
