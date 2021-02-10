using PopularityProgrammingLanguages.Core.Models;
using System.Collections.Generic; 

namespace PopularityProgrammingLanguages.Core.Interfaces
{
    public interface IWinnerResult
    {
        IEnumerable<SearchWinner> GetWinnersByEngine(IList<Search> searchData);

        SearchWinner GetWinnerAll(IList<Search> searchData);
    }
}
