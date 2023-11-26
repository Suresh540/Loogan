using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string? UserName { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        [BindProperty]
        public string? DisplayMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            DisplayMessage = "";
            if (string.IsNullOrEmpty(UserName))
            {
                DisplayMessage = "User name is empty";
                return Page();
            }
            if (string.IsNullOrEmpty(Password))
            {
                DisplayMessage = "Password is empty";
                return Page();
            }

            return RedirectToPage("/Dashboard/dashboard");
        }
    }
}
