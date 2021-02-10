
namespace PopularityProgrammingLanguages.Configuration.Configuration
{
    public class ConfigurationGoogle : ConfigurationBase
    {
        public static string GetBaseUrl()
        {
            return GetConfiguration("Google.BaseUrl");
        }

        public static string GetApiKey()
        {
            return GetConfiguration("Google.ApiKey");
        }

        public static string GetContextId()
        { 
                return GetConfiguration("Google.ContextId");
 
        }
    }
}
