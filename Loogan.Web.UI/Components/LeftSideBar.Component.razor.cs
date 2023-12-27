﻿using Loogan.Web.UI.Resources.Pages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
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

        [Inject]
        NavigationManager? navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UserName = _httpContext?.HttpContext?.Session?.GetString("FullName");
            UserType = _httpContext?.HttpContext?.Session?.GetString("LoginUserType");
            await base.OnInitializedAsync();
        }

        public async Task SignOut()
        {
            if (_httpContext != null && _httpContext.HttpContext != null)
            {
                _httpContext?.HttpContext?.Session.Clear();
                await _httpContext.HttpContext.SignOutAsync();
            }
            if (navigationManager != null)
            {
                navigationManager.NavigateTo("/", true);
            }
        }
    }
}
