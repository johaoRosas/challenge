using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopularityProgrammingLanguages.Services.Implementation;
using PopularityProgrammingLanguages.Services.IService;

namespace PopularityProgrammingLanguages.Test.Services
{
    [TestClass]
    public class BingTest
    {
        private ISearch _Isearch;

        public BingTest()
        {
            _Isearch = new BingSearch();
        }

        [TestMethod]
        public void GetResultsFromBing_Null_Exception()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _Isearch.GetResultTotalAsync(null)); 
        }

        [TestMethod]
        public void GetResultsFromBing_Empty_Exception()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _Isearch.GetResultTotalAsync(String.Empty));
        }

        [TestMethod]
        public void GetResultsFromBing_Success()
        { 
            var result = _Isearch.GetResultTotalAsync("java");
            Assert.IsNotNull(result);
        }

    }
}
