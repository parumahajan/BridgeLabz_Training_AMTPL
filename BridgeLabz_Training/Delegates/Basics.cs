/*
-----------------------------------------------
** DELEGATES ** 
-----------------------------------------------
 
-> It is a type which holds the reference to a method.

-> Basically, it acts like a pointer to function.

-> It is a variable, which can store the address of a method, which we can use, to call that method later.
-----------------------------------------------
LOOSE - COUPLING

-> One part of code doesn't depend tightly on another part.

-> The components know just enough to work with each other, but not the internal details.

-> Classes depend upon Abstraction (Interface and Delegates), and not on concrete implementations (specific methods/classes).

-> This makes system more flexible, maintainable, and easy to modify.
-----------------------------------------------
WHERE TO USE IT:

1) Events
-> Every event is built on delegates.

2) LINQ 
-> Uses lambda and delegates.

3) Callbacks
-> Used when a fn needs to call another fn.

4) Threading
-> ThreadStart Delegate
-----------------------------------------------
PURPOSE:

1) To treat methods like data. 
(store, pass, return, execute)

2) To achieve Loose-Coupling.

3) To enable Event-Driven Programming,
-----------------------------------------------
USES:

1) Used to call multiple methods, without knowing which method will actually run. (LOOSE COUPLING)

2) Used for Event Handling.

3) Used to write flexible and re-usable code.

4) Used to pass methods as Parameters.
-----------------------------------------------
WHAT IF WE DON'T USE IT ?

1) We're forced to write hard-coded method calls.
2) Code becomes rigid and non-extensible.
3) Event system would not work.
4) LINQ wouldn’t exist.
5) Callback functionality becomes difficult. 
-----------------------------------------------
TYPES OF DELEGATES:

1) SINGLE-CAST DELEGATE
2) MULTI-CAST DELEGATE
3) BUILT-IN DELEGATES
 
1) SINGLE-CAST DELEGATE
-> It stores only one method.

2) MULTI-CAST DELEGATE
-> It stores multiple methods, and then run them in sequence.

3) BUILT-IN DELEGATES
-> 1) valueFunc -> method with return value
   2) Action    -> method with no return 
   3) Predicate -> returns boolean
-----------------------------------------------
EXAMPLE: 

1) DECLARATION

-> public delegate void MyDelegate(string message);

SYNTAX:
<access_specifier> delegate <return_type>
<var_name> (<Parameters>)
-----------------------------------------------
2) METHODS WHICH MATCH DELEGATE SIGNATURE:

-> public static void Print(string message){
       Console.WriteLine("Print: " + message)
   }
   
   public static void Display(string message){
       Console.WriteLine("Display: " + message);
-----------------------------------------------
3) ASSIGN AND CALL
->  myDelegate del = Print;
    del("Hello");

    del = Display;
    del("Hi Again");
-----------------------------------------------
MULTI-CAST DELEGATE

MyDelegate del = Print;
del += Display;

del("Hello World");
-----------------------------------------------
ADVANTAGES:

1) Loose coupling
2) Flexible and Dynamic
3) Enable Lambda Expressions and LINQ
4) Supports Event-Driven Architecture 
-----------------------------------------------
DISADVANTAGES:

1) Hard to understand for beginners.
2) Multi-Cast delegates are tricky to debug.
3) If incorrectly used, then it may cause runtime errors.
-----------------------------------------------
CREATION OF DELEGATES:

1) Custom Delegate

->  We create it when we want a named, explicit-delegate type.


public static void Add(int x, int y){
        return a + b;
}

public delegate int Mathop(int x, int y);

Mathop add = new Methop(Add);
        
// delegate constructor with method group
// Add is another method, which we are passing as parameter

Mathop add2 = Add;

static int Add(int a, int b) => a + b;
-----------------------------------------------

2) BUILT-IN GENERIC DELEGATES

i) Func <int, int, int> add = (a,b) => a + b;
//    <T1, T2, TResult>

ii) Action <string> print = s => CW(s);

iii) Predicate<int> isEven = n => n % 2 == 0;
---------------------------------------------------




        












 
 
 
 
 
 
 */