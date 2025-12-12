using System;
using NUnit.Framework;
using BridgeLabz_Training.NUnit;

namespace Testing
{
    public class CalculatorTests
    {
        private Calculator _calculator = null!;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator("Pranav");
        }

        [Test]
        public void Constructor_ShouldSetOwner()
        {
            Assert.That(_calculator.Owner, Is.EqualTo("Pranav"));
        }

        [Test]
        public void Add_WhenGivenTwoNumbers_ReturnsSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_WhenSecondIsSmaller_ReturnsPositive()
        {
            int result = _calculator.Subtract(10, 3);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Multiply_WhenGivenTwoNumbers_ReturnsProduct()
        {
            int result = _calculator.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Divide_WhenDividingByNonZero_ReturnsQuotient()
        {
            int result = _calculator.Divide(10, 2);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_WhenDividingByZero_ThrowsException()
        {
            Assert.That(
                () => _calculator.Divide(10, 0),
                Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Constructor_WhenOwnerIsEmpty_ThrowsArgumentException()
        {
            Assert.That(
                () => new Calculator(""),
                Throws.TypeOf<ArgumentException>());
        }
    }
}
