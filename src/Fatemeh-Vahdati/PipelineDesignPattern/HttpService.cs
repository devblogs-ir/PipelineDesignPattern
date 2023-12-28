using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    internal class HttpService
    {
        public readonly HttpClient _client;
        public HttpService()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.All
            };
             
            _client = new HttpClient(handler);
        }

        public async Task<string> GetAsync(string uri)
        {
            using HttpResponseMessage responseMessage = await _client.GetAsync(uri);
            return await responseMessage.Content.ReadAsStringAsync();
        }

    }
}
