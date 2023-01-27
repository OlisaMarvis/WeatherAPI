using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.SharedKernel.HttpClientHelper
{
    public interface IHttpClientService
    {
        Task<Tout> GetAsync<Tout>(string requestUrl, Dictionary<string, string> headers = null);
        Task<Tout> PostAsync<Tin, Tout>(string requestUrl, Tin data, Dictionary<string, string> headers = null);
    }
}
