using System.Collections.Generic; 
using System.Threading.Tasks;
using PopularityProgrammingLanguages.Core.Models;

namespace PopularityProgrammingLanguages.Core.Interfaces
{
    public interface ISearchResults
    {
        Task<IList<Search>> GetSearchResults(IEnumerable<string> terms);
    }
}
