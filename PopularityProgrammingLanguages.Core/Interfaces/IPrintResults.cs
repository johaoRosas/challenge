using PopularityProgrammingLanguages.Core.Models;
using System.Collections.Generic;

namespace PopularityProgrammingLanguages.Core.Interfaces
{
    public interface IPrintResults
    {
        IList<string> GetSearchResultsReport(IList<Search> searchData);
        
        IList<string> GetWinnersReport(IEnumerable<SearchWinner> engineWinners);
        
        string GetGrandWinnerReport(SearchWinner grandWinner);
    }
}
