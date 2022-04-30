using System.Text.Json;
using KingGen.Models;

namespace KingGen;

public class KingGen
{
    private string _apiKey;
    public KingGen(string apiKey)
    {
        if (string.IsNullOrEmpty(apiKey.Trim())) throw new Exception("Invalid api key");
        _apiKey = apiKey;
    }

    public Profile? GetProfile() => MakeRequest<Profile>(Endpoint.Profile);

    public Alt? GetAlt()
    {
        var alt = MakeRequest<Alt>(Endpoint.Alt);
        if (alt?.Stock == 0 && string.IsNullOrWhiteSpace(alt.Email)) throw new Exception("Out of stock");
        return alt;
    }
    
    private T? MakeRequest<T>(Endpoint endpoint)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://kinggen.wtf/api/v2/" + endpoint.Build() + "?key=" + _apiKey),
        };
        var response = client.SendAsync(request);
        response.Wait();
        var reader = response.Result.Content?.ReadAsStringAsync();
        reader?.Wait();
        var json = reader?.Result;
        if ((int) response.Result.StatusCode < 300)
            return string.IsNullOrEmpty(json) ? default : JsonSerializer.Deserialize<T>(json!);
        var error = JsonSerializer.Deserialize<Error>(!string.IsNullOrEmpty(json) ? json! : "");
        throw new Exception(error?.Message);
    }
}