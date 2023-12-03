using Loogan.Common.Utilities;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Localization;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});
//.AddMicrosoftIdentityUI();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.AddMvc().AddMvcLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
builder.Services.AddTransient<IUtilityHelper>(opt =>
{
    return new UtilityHelper(builder.Configuration["LooganAPIUrl"]);
});
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<RequestLocalizationOptions>(options => {
    const string defaultCulture = "en-us";
    var supportedCultures = new[]
    {
        new CultureInfo(defaultCulture),
        new CultureInfo("en-GB")
    };
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();

//app.UseAuthorization();
app.MapRazorPages();

var supportedCultures = new[] { "en-US", "en-GB" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapBlazorHub();
app.MapControllers();
app.Run();
