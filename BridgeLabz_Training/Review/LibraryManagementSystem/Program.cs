using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Review.LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding sample books
            library.AddBook(new Book("The Alchemist", "Paulo Coelho", "Fiction"));
            library.AddBook(new Book("Clean Code", "Robert Martin", "Programming"));
            library.AddBook(new Book("Atomic Habits", "James Clear", "Self Help"));

            while (true)
            {
                Console.WriteLine("\n===== LIBRARY MENU =====");
                Console.WriteLine("1. Search Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("❌ Invalid choice.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Search by (title/author/genre): ");
                            string type = Console.ReadLine();

                            Console.Write("Enter search text: ");
                            string text = Console.ReadLine();

                            library.SearchBooks(type, text);
                            break;

                        case 2:
                            Console.Write("Enter book title to borrow: ");
                            library.BorrowBook(Console.ReadLine());
                            Console.WriteLine("✅ Book borrowed successfully.");
                            break;

                        case 3:
                            Console.Write("Enter book title to return: ");
                            library.ReturnBook(Console.ReadLine());
                            Console.WriteLine("✅ Book returned successfully.");
                            break;

                        case 4:
                            library.DisplayAllBooks();
                            break;

                        case 5:
                            Console.WriteLine("Exiting Library System...");
                            return;

                        default:
                            Console.WriteLine("❌ Choose between 1 and 5.");
                            break;
                    }
                }
                catch (BookAlreadyBorrowedException ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Unexpected Error: {ex.Message}");
                }
            }
        }
    }
}