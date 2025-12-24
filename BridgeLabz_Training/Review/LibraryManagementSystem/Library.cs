using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Review.LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void SearchBooks(string type, string value)
        {
            var results = type.ToLower() switch
            {
                "title" => books.Where(b => b.Title.Contains(value, StringComparison.OrdinalIgnoreCase)),
                "author" => books.Where(b => b.Author.Contains(value, StringComparison.OrdinalIgnoreCase)),
                "genre" => books.Where(b => b.Genre.Contains(value, StringComparison.OrdinalIgnoreCase)),
                _ => throw new ArgumentException("Invalid search type.")
            };

            if (!results.Any())
            {
                Console.WriteLine("❌ No books found.");
                return;
            }

            foreach (var book in results)
            {
                Console.WriteLine($"{book.Title} | {book.Author} | {book.Genre} | Available: {book.IsAvailable}");
            }
        }

        public void BorrowBook(string title)
        {
            Book book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                        ?? throw new ArgumentException("Book not found.");

            if (!book.IsAvailable)
            {
                throw new BookAlreadyBorrowedException("Book is already borrowed.");
            }

            book.IsAvailable = false;
        }

        public void ReturnBook(string title)
        {
            Book book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                        ?? throw new ArgumentException("Book not found.");

            book.IsAvailable = true;
        }

        public void DisplayAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} | {book.Author} | {book.Genre} | Available: {book.IsAvailable}");
            }
        }
    }
}
