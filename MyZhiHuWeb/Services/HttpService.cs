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

    public async Task<T> PostAsync<T>(string url, string body = "{}", string type = "application/json")
    {
        HttpContent content = new StringContent(body);
        content.Headers.ContentType = new MediaTypeHeaderValue(type);
        var address = configuration["API_URL"] + url;
        var res = await Client.PostAsync(address, content);
        var result = await res.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(result)!;
    }
}
