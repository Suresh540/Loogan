using Loogan.API.Models.Models;
using Loogan.Common.Utilities;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Loogan.Web.UI.Components
{
    public class ForgotComponentBase : ComponentBase
    {
        [Inject]
        public IConfiguration? configuration { get; set; }

        [Inject]
        public IEmailMessage? mailMessage { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IUtilityHelper _utilityHelper { get; set; }

        public string UserName { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public async Task SendEmail()
        {
            var settings = configuration.GetSection("EmailServer");
            var userModel = await _utilityHelper.ExecuteAPICall<ForgotPswdModel>(new ForgotPswdModel { UserName = UserName, EmailId = "", Password = "" }, RestSharp.Method.Post, resource: "api/User/GetUserEmailByUserName");
            if (settings != null && userModel != null)
            {
                SmtpDetails details = new SmtpDetails();
                details.Host = settings["Host"];
                details.Port = Convert.ToInt32(settings["Port"]);
                details.UserName = settings["UserName"];
                details.Password = settings["Password"];
                details.FromAddress = settings["FromAddress"];
                details.FromAddressDisplayName = settings["FromAddressDisplayName"];
                details.ToAddress = userModel.EmailId;
                details.Subject = settings["Subject"];
                details.Body = settings["Body"].Replace("{password}", userModel.Password);
                mailMessage.SendEmail(details);
                await JSRuntime.InvokeVoidAsync("sentMessage", "Mail sent successfully to email.");
            }
        }

    }
}
