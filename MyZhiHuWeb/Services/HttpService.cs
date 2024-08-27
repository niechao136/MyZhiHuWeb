using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MyZhiHuWeb.Services;

public class HttpService(IConfiguration configuration)
{

    private static readonly HttpClient Client = GetHttpClient();

    private static HttpClient GetHttpClient()
    {
        var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };
        var client = new HttpClient(handler);

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        client.Timeout = TimeSpan.FromSeconds(600);

        return client;
    }

    public async Task<T?> PostAsync<T>(string url, object? body, string type = "application/json", string api = "/api/")
    {
        HttpContent content = new StringContent(JsonConvert.SerializeObject(body ?? new {}));
        content.Headers.ContentType = new MediaTypeHeaderValue(type);
        var address = configuration["API_URL"] + api + url;
        var res = await Client.PostAsync(address, content);
        var str = await res.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(str);
    }
}
