using PopularityProgrammingLanguages.Core.Interfaces;
using PopularityProgrammingLanguages.Core.Models;
using PopularityProgrammingLanguages.Util.Shared;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PopularityProgrammingLanguages.Core.Implementation
{
    public class WinnerResult : IWinnerResult
    {
        public SearchWinner GetWinnerAll(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            Search searchWinner = searchData.GetMax(item => item.Results);
            return new SearchWinner() { Engine = searchWinner.SearchEngine, Word = searchWinner.Word };
        }

        public IEnumerable<SearchWinner> GetWinnersByEngine(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            IEnumerable<SearchWinner> searchEngines = searchData.GroupBy(data => data.SearchEngine,
                result => result, (searchEngine, results) => new SearchWinner
                {
                    Engine = searchEngine,
                    Word = results.GetMax(item => item.Results).Word
                });

            return searchEngines;
        }
    }
}
