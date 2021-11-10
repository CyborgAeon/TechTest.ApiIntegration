using ApiIntegration.Interfaces;
using ApiIntegration.ProviderModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ApiIntegration
{
    public class ApiDownloader : IApiDownloader
    {
        public async Task<ApiAvailabilityResponse> Download()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://tap.techtest.s3-website.eu-west-2.amazonaws.com/");
            var stream = await response.Content.ReadAsStreamAsync();
            using (var sr = new StreamContent(stream))
            {
                var serializedContent = await sr.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiAvailabilityResponse>(serializedContent);
            }
        }
    }
}
