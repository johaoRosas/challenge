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
    public class WinnerResultTest
    {
        private IWinnerResult _winnerResults;

        public WinnerResultTest()
        {
            _winnerResults = new WinnerResult();
        }

        [TestMethod]
        public void GetResultsWinnerByEngineResult_Null_Exception()
        {
            List<Search> searchData = null;
            Assert.ThrowsException<ArgumentException>(() => _winnerResults.GetWinnersByEngine(searchData));
        }

        [TestMethod]
        public void GetResultsWinnerByEngineResult_Empty_Exception()
        {
            List<Search> searchData = new List<Search>();
            Assert.ThrowsException<ArgumentException>(() => _winnerResults.GetWinnersByEngine(searchData));
        }

        [TestMethod]
        public void GetResultsWinnerByEngineResult_Success()
        {   
            var response =  _winnerResults.GetWinnersByEngine(GetTestData());
            Assert.IsNotNull(response);
            Assert.IsFalse(response.ToList().Count==0);

        }

        [TestMethod]
        public void GetResultsWinneAllResult_Null_Exception()
        {
            List<Search> searchData = null;
            Assert.ThrowsException<ArgumentException>(() => _winnerResults.GetWinnerAll(searchData));
        }

        [TestMethod]
        public void GetResultsWinneAllResult_Empty_Exception()
        {
            List<Search> searchData = new List<Search>();
            Assert.ThrowsException<ArgumentException>(() => _winnerResults.GetWinnerAll(searchData));
        }

        [TestMethod]
        public void GetResultsWinneAllResult_Success()
        {
            var response = _winnerResults.GetWinnerAll(GetTestData());
            Assert.IsNotNull(response);
        }



        private List<Search> GetTestData()
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
    }
}
