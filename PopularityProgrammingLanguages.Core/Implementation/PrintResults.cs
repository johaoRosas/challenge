using PopularityProgrammingLanguages.Core.Interfaces;
using PopularityProgrammingLanguages.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopularityProgrammingLanguages.Core.Implementation
{
    public class PrintResults : IPrintResults
    {

        public const string TOTAL_WINNER_TITLE = "Total winner: ";



        public IList<string> GetSearchResultsReport(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count == 0)
                throw new ArgumentException("The parameter is invalid", nameof(searchData));

            return searchData.GroupBy(item => item.Word)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.SearchEngine}: {item.Results}"))}")
                .ToList();
        }

        public IList<string> GetWinnersReport(IEnumerable<SearchWinner> engineWinners)
        {
            if (engineWinners == null || engineWinners.Count() == 0)
                throw new ArgumentException("The parameter is invalid", nameof(engineWinners));

            List<string> results = new List<string>();

            foreach (SearchWinner winner in engineWinners)
            {
                StringBuilder winnerBuilder = new StringBuilder();
                winnerBuilder.Append(winner.Engine + " winner : ");
                winnerBuilder.Append(winner.Word);
                results.Add(winnerBuilder.ToString());
            }

            return results;
        }

        public string GetGrandWinnerReport(SearchWinner grandWinner)
        {
            if (grandWinner == null)
                throw new ArgumentException("The parameter is invalid", nameof(grandWinner));

            StringBuilder grandWinnerBuilder = new StringBuilder();
            grandWinnerBuilder.Append(TOTAL_WINNER_TITLE);
            grandWinnerBuilder.Append(grandWinner.Word);
            return grandWinnerBuilder.ToString();
        }
    }
}
