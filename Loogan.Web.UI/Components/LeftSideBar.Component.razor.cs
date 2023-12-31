using Loogan.API.Models.Models;
using Loogan.Web.UI.Resources.Pages;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using NUglify.JavaScript.Syntax;
namespace Loogan.Web.UI.Components
{
    [AllowAnonymous]
    public class LeftSideBarBase : ComponentBase
    {
        [Inject]
        public required IStringLocalizer<ContentLabel>? Localizer { get; set; }

        [Inject]
        public IHttpContextAccessor? _httpContext { get; set; }

        public string? UserName { get; set; }

        public string? UserType { get; set; }

        public List<MenuModel>? RoleMenus { get; set; }

        [Inject]
        IUtilityHelper? _utilityHelper { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserName = _httpContext?.HttpContext?.Session?.GetString("FullName");
            UserType = _httpContext?.HttpContext?.Session?.GetString("LoginUserType");
            RoleMenuRequest request = new RoleMenuRequest()
            {
                RoleId = Convert.ToInt32(_httpContext?.HttpContext?.Session?.GetInt32("LoginUserTypeId")),
                LanguageId = _httpContext?.HttpContext?.Session.GetInt32("LanguageId") ?? 1
            };

            if (_utilityHelper != null)
            {
                RoleMenus = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(request, RestSharp.Method.Post, resource: "api/Admin/GetRoleMenus");
            }
            await CallJavascript();
            await base.OnInitializedAsync();
        }

        public async Task CallJavascript()
        {
            await jsRuntime.InvokeVoidAsync("liTabClick");
        }
    }
}
