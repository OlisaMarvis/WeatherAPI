namespace WeatherApp.WEBApi.Shared.HttpClientHelper
{
    public interface IHttpClientService
    {
        Task<Tout> GetAsync<Tout>(string requestUrl, Dictionary<string, string> headers = null);
    }
}
