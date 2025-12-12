// 1) Achieve Multiple inheritance
// 2) Create a custom exception, and utilize the custom exception and utilize it.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Exceptions
{
    public class Exception_Review
    {

        public interface IException
        {
            void Review();
        }

        public interface IException2
        {
            int Review2 { get; }
        }

        public class EmployeeNotFound : Exception
        {
            public EmployeeNotFound(string Message) : base(Message)
            {
               
            }
        }
        

    }
}