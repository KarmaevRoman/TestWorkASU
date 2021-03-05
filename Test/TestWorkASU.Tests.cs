using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestWorkASU.Model;
using TestWorkASU.ViewModel;

namespace TestWorkASU.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLineFunc()
        {
            var testLineFunc = new ComponentFunctionVM() { ACoefficient = 5, BCoefficient = 6, CCoefficient = 3, X = "10", Y = "11", NameFunction = "линейная" };

            var resalt = CalculateResult.Result(testLineFunc);

            Assert.AreEqual(59, resalt);
        }

        [TestMethod]
        public void TestSecondGreede()
        {
            var testLineFunc = new ComponentFunctionVM() { ACoefficient = 5, BCoefficient = 6, CCoefficient = 30, X = "10", Y = "11", NameFunction = "квадратичная" };

            var resalt = CalculateResult.Result(testLineFunc);

            Assert.AreEqual(596, resalt);
        }

        [TestMethod]
        public void TestThirdGreede()
        {
            var testLineFunc = new ComponentFunctionVM() { ACoefficient = 5, BCoefficient = 6, CCoefficient = 300, X = "10", Y = "11", NameFunction = "кубическая" };

            var resalt = CalculateResult.Result(testLineFunc);

            Assert.AreEqual(6026, resalt);
        }

        [TestMethod]
        public void TestFourthGreede()
        {
            var testLineFunc = new ComponentFunctionVM() { ACoefficient = 5, BCoefficient = 6, CCoefficient = 3000, X = "10", Y = "11", NameFunction = "4-ой степени" };

            var resalt = CalculateResult.Result(testLineFunc);

            Assert.AreEqual(60986, resalt);
        }


        [TestMethod]
        public void TestFifthGreede()
        {
            var testLineFunc = new ComponentFunctionVM() { ACoefficient = 5, BCoefficient = 6, CCoefficient = 30000, X = "10", Y = "11", NameFunction = "5-ой степени" };

            var resalt = CalculateResult.Result(testLineFunc);

            Assert.AreEqual(617846, resalt);
        }        
    }
}
