using System.Configuration;

namespace PopularityProgrammingLanguages.Configuration.Configuration
{
    public class ConfigurationBase 
    {
     private const string MISSING_CONFIGURATION = "There was an isue with the configuration file. (Missing Value: {Key})";

    
        public static string GetConfiguration(string key)
        {

            string configurationValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(MISSING_CONFIGURATION.Replace("{Key}", key));

            return configurationValue;
        }

    }
}
