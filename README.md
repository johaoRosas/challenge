Simple Console App that queries search engines and compares how many results they
return.
input parameters: .net java
Results:
.net: Google: 13200000 MSN Search: 15600000
java: Google: 405000 MSN Search: 20700000
Google winner: .net
MSN Search winner: java
Total winner: .net
Prerequisites
Because it is using the google search engine and bing, the application needs 3 keys to
work:
Google API Key
Google Custom Engine Key
Bing Search Engine Key
Once you have it, Just Update the following keys in the Config file
key="GoogleAPIKey" value="YOUR_GOOGLE_API_KEY_HERE"
key="GoogleCEKey" value="YOUR_GOOGLE_CUSTOM_ENGINE_KEY_HERE"
key="BingKey" value="YOUR_BING_API_KEY_HERE"
Wanna add another search engine?
Just add another client class and implement ISearchClient, and that's it !
Development
- Include unit testing (>80% coverage)
- Use good development patterns