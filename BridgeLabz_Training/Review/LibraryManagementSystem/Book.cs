using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Review.LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = true;
        }
    }
}