using System.Linq;
using MyCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void LoadOperationsTest()
        {
            var calc = new Calculator();
            Assert.IsTrue(calc.Operations.Any());
        }
        [TestMethod]
        public void AdditionTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("1+2+3"), 6);
        }
        [TestMethod]
        public void SubtractionTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("1-2-3"), -4);
        }
        [TestMethod]
        public void ZeroDivisionTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("9/0"), 0);
        }
        [TestMethod]
        public void DivisionTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("8/2/2"), 2);
        }
        [TestMethod]
        public void MultiplicationTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("5*5*5"), 125);
        }
        [TestMethod]
        public void PriorityTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("2+2*2"), 6);
        }

        [TestMethod]
        public void ParenthesisTest()
        {
            var calc = new Calculator();
            Assert.AreEqual(calc.Calculate("(2+2)*2"), 8);
        }
    }
}
