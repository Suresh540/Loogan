using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;
using Microsoft.JSInterop;

namespace Loogan.Web.UI.Components
{
    public class PagingBase : ComponentBase
    {
        [Parameter]
        public int TotalRecords { get; set; }

        [Parameter]
        public string NavigateURL { get; set; }

        [Parameter]
        public string? TotalRecordsURL { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        [Inject]
        IJSRuntime? jSRuntime { get; set; }   

        public async Task selectChange(string value)
        {
            PageSize = Convert.ToInt32(value);
            await jSRuntime.InvokeVoidAsync(NavigateURL, PageIndex, PageSize);
        }

        public async Task onPrevious()
        {
            if (PageIndex > 0)
            {
                PageIndex -= 1;
                await jSRuntime.InvokeVoidAsync(NavigateURL, PageIndex, PageSize);
            }
        }

        public async Task onNext()
        {
            if (PageIndex <= TotalRecords)
            {
                PageIndex += 1;
            }
            var totalRecords = await jSRuntime.InvokeAsync<int>(TotalRecordsURL);
            var totalPage = (int)Math.Ceiling((double)totalRecords / PageSize);
            if (PageIndex <= totalPage)
            {
                await jSRuntime.InvokeVoidAsync(NavigateURL, PageIndex, PageSize);
            }
        }
    }
}
