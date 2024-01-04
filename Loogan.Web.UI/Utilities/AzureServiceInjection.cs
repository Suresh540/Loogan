using Loogan.Common.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Globalization;

namespace Loogan.Web.UI.Utilities
{
    public static class AzureAuthorizeServiceInjection
    {
        public static IServiceCollection AddMultiAuthorizeService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddLocalization(options => options.ResourcesPath = "");
            services.AddMvc().AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
                            .AddDataAnnotationsLocalization();

            services.AddTransient<IUtilityHelper>(opt =>
            {
                return new UtilityHelper(configuration["LooganAPIUrl"]);
            });

            var auth = services.AddAuthentication(options =>
             {
                 options.DefaultScheme = "MultiAuthSchemas";
                 options.DefaultChallengeScheme = "MultiAuthSchemas";

             });
            auth.AddJwtBearer();
            auth.AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
            auth.AddPolicyScheme("MultiAuthSchemas", "MultiAuthSchemas", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    var path = context.Request.Path.Value;
                    if (path.ToLower().Contains("azure"))
                    {
                        return OpenIdConnectDefaults.AuthenticationScheme;
                    }
                    else
                    {
                        return CookieAuthenticationDefaults.AuthenticationScheme;
                    }
                };
            });
            services.AddAuthorization(opt =>
            {
                opt.FallbackPolicy = opt.DefaultPolicy;
            });
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
                options.Conventions.AuthorizePage("/Admin/AdminDashboard");
            }).AddMicrosoftIdentityUI();
            services.AddServerSideBlazor();

            services.AddSingleton<IAuthorizationHandler, LooganAdminAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, LooganStudentAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, LooganTeacherAuthorizationHandler>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IEmailMessage, EmailMessage>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                const string defaultCulture = "en-US";
                var supportedCultures = new[]
                {
                    new CultureInfo(defaultCulture),
                    new CultureInfo("fr-FR")
                };
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            return services;
        }
    }
}
