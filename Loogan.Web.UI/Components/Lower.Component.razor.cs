using Loogan.Web.UI.Resources.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Net.NetworkInformation;

namespace Loogan.Web.UI.Components
{
    public class LowerComponentBase : ComponentBase
    {

        [Inject]
        public IStringLocalizer<ContentLabel> Localizer { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
