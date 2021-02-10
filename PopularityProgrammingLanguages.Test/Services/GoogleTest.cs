using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopularityProgrammingLanguages.Services.Implementation;
using PopularityProgrammingLanguages.Services.IService;

namespace PopularityProgrammingLanguages.Test.Services
{
    [TestClass]
    public class GoogleTest
    {
        private ISearch _Isearch;

        public GoogleTest()
        {
            _Isearch = new GoogleSearch();
        }

        [TestMethod]
        public void GetResultsFromGoogle_Null_Exception()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _Isearch.GetResultTotalAsync(null));
        }

        [TestMethod]
        public void GetResultsFromGoogle_Empty_Exception()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _Isearch.GetResultTotalAsync(String.Empty));
        }

        [TestMethod]
        public void GetResultsFromGoogle_Success()
        {
            var result =  _Isearch.GetResultTotalAsync(".net");
            Assert.IsNotNull(result); 
        }
    }
}
