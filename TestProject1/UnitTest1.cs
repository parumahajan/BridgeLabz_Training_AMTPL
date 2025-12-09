using NUnit.Framework;
using BridgeLabz_Training.NUnit;   // <– this is where Calculator lives

namespace TestProject1              // <– keep test project’s own namespace
{
    [TestFixture]
    public class Calculator
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Constructor_WithValidOwner_SetsOwnerProperty()
        {
            Assert.IsNotNull(_calculator);
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(3, 7);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void IsPositive_PositiveNumber_ReturnsTrue()
        {
            bool result = _calculator.IsPositive(5);
            Assert.IsTrue(result);
        }

        [Test]
        public void Divide_ByNonZero_ReturnsQuotient()
        {
            int result = _calculator.Divide(20, 5);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Test]
        public void Constructor_WithEmptyOwner_ThrowsArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => new Calculator(""));
        }
    }
}
