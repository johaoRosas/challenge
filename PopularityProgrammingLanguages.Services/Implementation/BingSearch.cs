using PopularityProgrammingLanguages.Services.IService;
using PopularityProgrammingLanguages.Configuration.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System;
using PopularityProgrammingLanguages.Services.Models.Bing;
using System.Net.Http.Headers;

namespace PopularityProgrammingLanguages.Services.Implementation
{
    public class BingSearch  : ISearch
    {
        public string Name => "Bing";
        private static HttpClient _client = new HttpClient();

        public BingSearch()
        {
           
        }


        public async Task<long> GetResultTotalAsync(string word)
        { 
                long searchCount = default(long);
             
                string requestUrl = ConfigurationBing.GetBaseUrl().Replace("{Query}", word);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUrl),
                };

                request.Headers.Add("Ocp-Apim-Subscription-Key", ConfigurationBing.GetApiKey());
                System.Net.ServicePointManager.SecurityProtocol =System.Net.SecurityProtocolType.Tls12;
                using (var response = await _client.SendAsync(request))
                 {
                     if (!response.IsSuccessStatusCode)
                         throw new Exception("We weren't able to process your request. Please try again later.");

                     var serializer = new DataContractJsonSerializer(typeof(BingMain));
                     var streamContent = await response.Content.ReadAsStreamAsync();
                     var data = (BingMain)serializer.ReadObject(streamContent);

                     searchCount = data.webPages.totalEstimatedMatches;
                 } 

                return searchCount;
           
            
        }
    }
}
