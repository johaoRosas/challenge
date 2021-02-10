using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using PopularityProgrammingLanguages.Core.Interfaces;
using PopularityProgrammingLanguages.Services.IService;
using PopularityProgrammingLanguages.Core.Models; 

namespace PopularityProgrammingLanguages.Core.Implementation
{
    public class SearchResults : ISearchResults
    {

        private IEnumerable<ISearch> _searchEngines;

        public SearchResults()
        {
            _searchEngines = GetImplementedSearchEngines();
        }

        public async Task<IList<Search>> GetSearchResults(IEnumerable <string> words)
        {
            if (words == null || words.Count() == 0)
                throw new ArgumentException("The  argument is invalid.", nameof(words));

            IList<Search> results = new List<Search>();

            foreach (ISearch engine in _searchEngines)
            {
                foreach (string word in words)
                {
                    results.Add(new Search
                    {
                        SearchEngine = engine.Name,
                        Word = word,
                        Results = await engine.GetResultTotalAsync(word)
                    });
                }
            }

            return results;
        }

        private IEnumerable<ISearch> GetImplementedSearchEngines()
        {
            IEnumerable<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("PopularityProgrammingLanguages"));

            return loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearch).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearch).ToList();
        }
    }
}
