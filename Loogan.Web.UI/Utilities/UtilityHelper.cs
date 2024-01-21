using Loogan.Common.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Mime;

namespace Loogan.Web.UI.Utilities;

public class UtilityHelper : IUtilityHelper
{
    private readonly string? _baseUrl;

    public UtilityHelper(string? baseUrl)
    {
        this._baseUrl = baseUrl;
    }

    public async Task<T?> ExecuteAPICall<T>(object? reqParams, Method method,
        Dictionary<string, object>? header = null, string resource = "")
    {
        T? result = default(T);
        using (RestClient client = new RestClient(_baseUrl))
        {
            RestRequest request = new RestRequest();
            request = new RestRequest(resource);
            request.Method = method;
            if (reqParams != null)
            {
                request.AddBody(reqParams);
            }
            if (header != null)
            {
                foreach (var item in header)
                {
                    request.AddHeader(item.Key, item.Value?.ToString());
                }
            }
            var response = await client.ExecuteAsync<T>(request);
            if (response != null && response.IsSuccessStatusCode)
            {
                result = response.Data;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorMessage>(response.Content);
                throw new Exception(error.Message);
            }
        }
        return result;
    }
}

