/*
---------------------------------------------------
** LAMBDA **

-> It is a short block of code which acts as an anonymous function, and is used wherever a delegate type is expected.
 
-> It takes parameters and return a value.

-> It helps to make the code more concise, and also enables function-style programming.
---------------------------------------------------
SYNTAX:
(parameters) => expression or statement-block
---------------------------------------------------
EXAMPLE:

// For Single Variable
x => x * 2;

// For Multiple Variables
(x,y) => {
            var sum = x + y;           
            return sum * 2;
         }
---------------------------------------------------
ADVANTAGES:
1) Concise (need to write less code)
2) Expressive (improves readability)
3) Powerful (as state can be carried as fn)
4) Inter-operability 
5) Flexibility
6) Enables Expression-Trees
---------------------------------------------------
DISADVANTAGES:
1) Can affect readability, if overused.
2) Can create Closure Traps.
3) Harder to debug
4) Potentially unintended memory retention
---------------------------------------------------
IMPLEMENTATION:
---------------------------------------------------
1) LAMBDA IN LINQ:

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        var evenNumbers = numbers.Where(n => n % 2 == 0);

        // For each element n, check whether n is divisible by 2.

        foreach (var n in evenNumbers)
            Console.WriteLine(n);
    }
}
---------------------------------------------------
2) LAMBDA IN DELEGATES:

using System;

class Program
{
    static void Main()
    {
        Func<int, int, int> add = (a,b) => a + b;

        int result = add(10, 20);
        Console.WriteLine(result);
    }
}
---------------------------------------------------
3) LAMBDA IN EVENT

using System;

class Button
{
    public event Action Click;

    public void Press()
    {
        Click?.Invoke();
    }
}

class Program
{
    static void Main()
    {
        Button btn = new Button();

        btn.Click += () => Console.WriteLine("Button clicked!");

        btn.Press();
    }
}
---------------------------------------------------
4) LAMBDA IN CALLBACKS

using System;

class Program
{
    static void ProcessNumber(int number, Action<int> callback)
    {
        int result = number * 2;
        callback(result);   // callback invoked
    }

    static void Main()
    {
        ProcessNumber(5, result => Console.WriteLine(result));
    }
}
---------------------------------------------------
5) LAMBDA IN EXPRESSION TREES

using System;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        Expression<Func<int, bool>> expr = x => x > 10;

        Console.WriteLine(expr);
    }
}
---------------------------------------------------
 
 
 
 
 
 
 
 
 
 
 
 
 
 */