using PopularityProgrammingLanguages.Configuration.Configuration;
using PopularityProgrammingLanguages.Services.IService;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using PopularityProgrammingLanguages.Services.Models.Google;

namespace PopularityProgrammingLanguages.Services.Implementation
{
    public class GoogleSearch : ISearch
    {
        public string Name => "Google";
        private HttpClient _client { get; }

        public GoogleSearch()
        {
            _client = new HttpClient();
        }


        public async Task<long> GetResultTotalAsync(string word)
        {
            long searchCount = default(long);

            string requestUrl = ConfigurationGoogle.GetBaseUrl().Replace("{Key}", ConfigurationGoogle.GetApiKey())
        .Replace("{Context}", ConfigurationGoogle.GetContextId())
        .Replace("{Query}", word);

            using (var response = await _client.GetStreamAsync(requestUrl))
            {
                var serializer = new DataContractJsonSerializer(typeof(GoogleMain));
                var data = (GoogleMain)serializer.ReadObject(response);

                searchCount = data.queries.request[0].totalResults;
            }

            return searchCount;
        }
    }
}
