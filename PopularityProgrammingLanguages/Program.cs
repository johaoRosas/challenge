using PopularityProgrammingLanguages.Core.Implementation;
using PopularityProgrammingLanguages.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopularityProgrammingLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your words: ");
            var searchText = Console.ReadLine();
            if (string.IsNullOrEmpty(searchText) || searchText.Split(' ').Length < 2)
            {
                Console.WriteLine("You have to enter at least two words ");
                return;
            }

            var result = searchText.Split('"')
                     .Select((element, index) => index % 2 == 0 
                                           ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  
                                           : new string[] { element }) 
                     .SelectMany(element => element).ToArray();

      

             MainAsync(result).GetAwaiter().GetResult();


        }



        public static List<string> Reports { get; private set; }

        static ISearchResults SearchManager;
        static IWinnerResult WinnerManager;
        static IPrintResults PrintResult;

        static async Task MainAsync(string[] args)
        {
            SearchManager = new SearchResults();
            WinnerManager = new WinnerResult();
             PrintResult = new PrintResults();
            Reports = new List<string>();

            var result = await SearchManager.GetSearchResults(args);
            var searchEngineGroup = WinnerManager.GetWinnersByEngine(result);
            var winnerAll = WinnerManager.GetWinnerAll(result);

            Reports.AddRange(PrintResult.GetSearchResultsReport(result));
            Reports.AddRange(PrintResult.GetWinnersReport(searchEngineGroup));
            Reports.Add(PrintResult.GetGrandWinnerReport(winnerAll));

            Reports.ForEach(report => Console.WriteLine(report));
            Console.ReadLine();


        }


    }
}
