using RestSharp;

namespace Loogan.Web.UI.Utilities;

public interface IUtilityHelper
{
    public Task<T?> ExecuteAPICall<T>(object? reqParams, Method method, Dictionary<string, object>? header = null, string resource = "");
}

