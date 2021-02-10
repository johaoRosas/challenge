using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopularityProgrammingLanguages.Core.Implementation;
using PopularityProgrammingLanguages.Core.Interfaces;
using PopularityProgrammingLanguages.Core.Models;

namespace PopularityProgrammingLanguages.Test.Core
{
    [TestClass]
    public class PrintResultsTest
    {
        private IPrintResults _printResults;

        public PrintResultsTest()
        {
            _printResults = new PrintResults();
        }
 

        [TestMethod]
        public void GetSearchResultsReport_Null_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _printResults.GetSearchResultsReport(null));
        }


        [TestMethod]
        public void GetSearchResultsReport_Empty_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _printResults.GetSearchResultsReport(new List<Search>()));
        }


        [TestMethod]
        public void GetSearchResultsReport_Success()
        {
            IList<string> response =  _printResults.GetSearchResultsReport(GetTestDataSearch());
            Assert.IsNotNull(response);
            Assert.IsFalse(response.ToList().Count == 0);

        }


        [TestMethod]
        public void GetWinnersReport_Null_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _printResults.GetWinnersReport(null));
        }

        [TestMethod]
        public void GetWinnersReport_Empty_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _printResults.GetWinnersReport(new List<SearchWinner>()));
        }

        [TestMethod]
        public void GetWinnersReport_Success()
        {
            IList<string> response = _printResults.GetWinnersReport(GetTestData());
            Assert.IsNotNull(response);
            Assert.IsFalse(response.ToList().Count == 0);

        }


        [TestMethod]
        public void GetAllWinnersReport_Null_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _printResults.GetGrandWinnerReport(null));
        }

 

        [TestMethod]
        public void GetAllWinnersRepor_Success()
        {
            string response = _printResults.GetGrandWinnerReport(GetTestAllWinner());
            Assert.IsNotNull(response);

        }


        public SearchWinner GetTestAllWinner()
        {
            return new SearchWinner { Engine = "Google", Word = ".NET" };
        }

        private List<Search> GetTestDataSearch()
        {
            List<Search> testData = new List<Search>
            {
                new Search { SearchEngine = "Google", Word = ".NET", Results = 24340401L },
                new Search { SearchEngine = "Bing", Word = ".NET", Results = 12493849L },

                new Search { SearchEngine = "Google", Word = "Java", Results = 55419851L },
                new Search { SearchEngine = "Bing", Word = "Java", Results = 53091305L },

                new Search { SearchEngine = "Google", Word = "Java script", Results = 36048304L },
                new Search { SearchEngine = "Bing", Word = "Java script", Results = 65048139L },

                new Search { SearchEngine = "Google", Word = "python", Results = 24408158L },
                new Search { SearchEngine = "Bing", Word = "python", Results = 32058984L }
            };

            return testData;
        }

        private List<SearchWinner> GetTestData()
        {
            List<SearchWinner> testData = new List<SearchWinner>
            {
                new SearchWinner { Engine = "Google", Word = ".NET" },
                new SearchWinner { Engine = "Bing", Word = ".NET"},

                new SearchWinner { Engine = "Google", Word = "Java" },
                new SearchWinner { Engine = "Bing", Word = "Java" },

                new SearchWinner { Engine = "Google", Word = "Java script"},
                new SearchWinner { Engine = "Bing", Word = "Java script" },

                new SearchWinner { Engine = "Google", Word = "python" },
                new SearchWinner { Engine = "Bing", Word = "python" }
            };

            return testData;
        }

    }
}
