using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Service.Core
{
    public class BaseClient
    {
        protected readonly UriBuilder _uriBuilder;
        protected readonly string _endpoint;
        public BaseClient(string endpoint)
        {
            _endpoint = endpoint;
            _uriBuilder = new UriBuilder(_endpoint);
            
        }
        protected async Task<T> ExtractDataFromAPI<T>(string queryString)
        {
            using (var httpClient = new HttpClient())
            {
                _uriBuilder.Query = queryString;
                HttpResponseMessage response = await httpClient.GetAsync(_uriBuilder.ToString());
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
        }
    }
}
