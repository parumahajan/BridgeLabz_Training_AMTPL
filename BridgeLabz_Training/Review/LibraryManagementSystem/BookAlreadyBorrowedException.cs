using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Review.LibraryManagementSystem
{
    public class BookAlreadyBorrowedException : Exception
    {
        public BookAlreadyBorrowedException(string message) : base(message)
        {
        }
    }
}