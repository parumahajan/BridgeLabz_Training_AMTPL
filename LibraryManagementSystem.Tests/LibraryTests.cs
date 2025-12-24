using NUnit.Framework;
using System;

// IMPORTANT: Correct namespace of code under test
using BridgeLabz_Training.Review.LibraryManagementSystem;

namespace LibraryManagementSystem.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();

            // Add a sample book before each test
            library.AddBook(new Book(
                "Clean Code",
                "Robert Martin",
                "Programming"
            ));
        }

        [Test]
        public void BorrowBook_AvailableBook_ShouldMarkAsUnavailable()
        {
            library.BorrowBook("Clean Code");

            // Borrowing again should throw exception
            Assert.Throws<BookAlreadyBorrowedException>(() =>
                library.BorrowBook("Clean Code"));
        }

        [Test]
        public void BorrowBook_NonExistingBook_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                library.BorrowBook("Unknown Book"));
        }

        [Test]
        public void ReturnBook_BorrowedBook_ShouldMakeItAvailableAgain()
        {
            library.BorrowBook("Clean Code");

            library.ReturnBook("Clean Code");

            // After returning, borrowing again should work
            Assert.DoesNotThrow(() =>
                library.BorrowBook("Clean Code"));
        }

        [Test]
        public void ReturnBook_NonExistingBook_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                library.ReturnBook("Unknown Book"));
        }
    }
}