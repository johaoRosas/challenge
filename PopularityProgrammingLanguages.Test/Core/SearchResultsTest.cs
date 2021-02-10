using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopularityProgrammingLanguages.Core.Implementation;
using PopularityProgrammingLanguages.Core.Interfaces;

namespace PopularityProgrammingLanguages.Test.Core
{
    [TestClass]
    public class SearchResultsTest
    {
        private ISearchResults _searchResults;

        public SearchResultsTest()
        {
            _searchResults = new SearchResults();
        }

        [TestMethod]
        public void GetResultsSearchResult_Null_Exception()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchResults.GetSearchResults(null));
        }

        [TestMethod]
        public void GetResultsSearchResult_Empty_Exception()
        {
            List<string> words = new List<string>();
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchResults.GetSearchResults(words));
        }

        [TestMethod]
        public void GetResultsSearchResult_Success()
        {
            List<string> words = new List<string> { ".NET", "Java", "java script", "node js" };
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchResults.GetSearchResults(words));
        }




    }
}
