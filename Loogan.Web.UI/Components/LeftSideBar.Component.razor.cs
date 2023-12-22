using Loogan.Web.UI.Resources.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
namespace Loogan.Web.UI.Components
{
    public class LeftSideBarBase : ComponentBase
    {
        [Inject]
        public required IStringLocalizer<ContentLabel>? Localizer { get; set; }

        [Inject]
        public IHttpContextAccessor? _httpContext { get; set; }

        public string? UserName { get; set; }

        public string? UserType { get; set; }

        protected override void OnInitialized()
        {
            UserName = _httpContext?.HttpContext?.Session?.GetString("UserName");
            UserType = _httpContext?.HttpContext?.Session?.GetString("LoginUserType");
            base.OnInitialized();
        }
    }
}
