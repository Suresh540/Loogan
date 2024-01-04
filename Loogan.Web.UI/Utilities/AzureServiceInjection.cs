using Loogan.Common.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Globalization;

namespace Loogan.Web.UI.Utilities
{
    public static class AzureAuthorizeServiceInjection
    {
        public static IServiceCollection AddAzureAuthorizeService(this IServiceCollection services, IConfiguration configuration)
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

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });
            services.AddServerSideBlazor();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
                options.Conventions.AuthorizePage("/Admin/AdminDashboard");
            }).AddMicrosoftIdentityUI();

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
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
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

    public static class SqlAuthorizeServiceInjection
    {
        public static IServiceCollection AddSqlAuthorizeService(this IServiceCollection services, IConfiguration configuration)
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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = new PathString("/");
                                options.LogoutPath = new PathString("/Logout");
                                options.AccessDeniedPath = new PathString("/Access");
                            });
            services.AddAuthorization();
            services.AddServerSideBlazor();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
                options.Conventions.AuthorizePage("/Admin/AdminDashboard");
            });

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
