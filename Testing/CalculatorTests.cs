using System;
using NUnit.Framework;                  // NUnit attributes and assertions

using BridgeLabz_Training.NUnit;        // Access to Calculator class

namespace Testing
{
    // This class contains test cases for the Calculator class
    // NUnit discovers this class using reflection
    public class CalculatorTests
    {
        // Field to hold Calculator object for testing
        // null! is used to suppress compiler warnings
        // because the object will be initialized in [SetUp]
        private Calculator _calculator = null!;

        // [SetUp] runs BEFORE EACH test method
        // Ensures every test gets a fresh Calculator instance
        [SetUp]
        public void Setup()
        {
            // Creating a valid Calculator object
            _calculator = new Calculator("Pranav");
        }

        // [Test] tells NUnit that this method is a test case
        [Test]
        public void Constructor_ShouldSetOwner()
        {
            // Act + Assert
            // Checking whether constructor correctly sets the Owner property
            Assert.That(_calculator.Owner, Is.EqualTo("Pranav"));
        }

        [Test]
        public void Add_WhenGivenTwoNumbers_ReturnsSum()
        {
            // Act
            int result = _calculator.Add(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_WhenSecondIsSmaller_ReturnsPositive()
        {
            // Act
            int result = _calculator.Subtract(10, 3);

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Multiply_WhenGivenTwoNumbers_ReturnsProduct()
        {
            // Act
            int result = _calculator.Multiply(4, 5);

            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Divide_WhenDividingByNonZero_ReturnsQuotient()
        {
            // Act
            int result = _calculator.Divide(10, 2);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_WhenDividingByZero_ThrowsException()
        {
            // Assert.That with lambda expression:
            // The lambda delays execution so NUnit can catch the exception
            Assert.That(
                () => _calculator.Divide(10, 0),
                Throws.TypeOf<DivideByZeroException>()
            );
        }

        [Test]
        public void Constructor_WhenOwnerIsEmpty_ThrowsArgumentException()
        {
            // Testing constructor validation logic
            Assert.That(
                () => new Calculator(""),
                Throws.TypeOf<ArgumentException>()
            );
        }
    }
}