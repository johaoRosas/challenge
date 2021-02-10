

namespace PopularityProgrammingLanguages.Configuration.Configuration
{
    public class ConfigurationBing : ConfigurationBase
    {
        public static string GetBaseUrl()
        {
             
                return GetConfiguration("Bing.BaseUrl");
            
        }

        public static string GetApiKey()
        {
             
                return GetConfiguration("Bing.ApiKey");
            
        }
    }
}
