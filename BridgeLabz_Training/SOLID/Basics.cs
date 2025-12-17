/*
---------------------------------------------------
** SOLID DESIGN PRINCIPLES **
---------------------------------------------------
- Design Principles are GUIDELINES which are used to write Clean, Maintainable, Scalable, and Testable code.

- They guide how to design classes, methods, and systems, especially in object-oriented programming like C#.

Without Principles	  With Principles

Spaghetti code   	  Clean architecture
Hard to modify	      Easy to extend
Bug-prone	          Stable
Tightly coupled	      Loosely coupled
Difficult testing	  Easy unit testing
---------------------------------------------------
1️) S — Single Responsibility Principle (SRP)
---------------------------------------------------
-> A class should have only ONE reason to change.
 
- Rather than, one class doing entire thing (doing multiple operations), we can instead create multiple classes, which do the work individually, more specifically and efficiently.

- We assign only one responsibility to each class.
---------------------------------------------------
Advantages:

- Easier debugging
- Better testability

Disadvantages:

- Due to more classes, code length and token count increases.
---------------------------------------------------
Used in:

1) Service classes 
-> contains business logic. 
-> and Actual work happens here.

2) Business logic layers
-> contains service  classes, domain logic, and rules.
 
3) Controllers 
-> entry point of a request. (routing purpose)
-> receives input, calls required services, and returns output.
---------------------------------------------------
EXAMPLE:

BAD DESIGN:

class Report
{
    public void GenerateReport() { }
    public void SaveToFile() { }
    public void PrintReport() { }
}

GOOD DESIGN:

class ReportGenerator { }
class ReportSaver { }
class ReportPrinter { }
---------------------------------------------------
2️) O — Open/Closed Principle (OCP)
---------------------------------------------------
1) Open for extension 
→ We can add new features (behavior)

2) Closed for modification 
→ We don't need to edit already working code.
---------------------------------------------------
We use this because:
- Changing existing code can break working functionality.
- Old code may already be tested, deployed, and stable.
---------------------------------------------------
Advantage:
- Prevents breaking old code

Disadvantage:
- Needs proper abstraction planning
---------------------------------------------------
Used in: 
- Frameworks
- Plugins
- Payment gateways
---------------------------------------------------
Bad Design:

if(type == "PDF") { }
else if(type == "Word") { }

Good Design (Polymorphism):

interface IReport
{
    void Generate();
}

class PdfReport  : IReport { }
class WordReport : IReport { }
---------------------------------------------------
3) L — Liskov Substitution Principle (LSP)
---------------------------------------------------
-> Derived class should replace base class without breaking behavior.

- If a class B is a child of class A, then we should be able to use B wherever A is used — without the program breaking or behaving incorrectly.

- Inheritance should be trustworthy.

- “If it looks like the parent, then it should act like the parent.”
---------------------------------------------------
Purpose: Reliable inheritance
Advantage: Predictable polymorphism
---------------------------------------------------
VIOLATION EXAMPLE:

class Bird
{
    public virtual void Fly() { }
}

class Ostrich : Bird
{
    public override void Fly()
    {
        throw new Exception();
    }
}
---------------------------------------------------
CORRECT DESIGN:

interface IFlyable { void Fly(); }
---------------------------------------------------
4️) I — Interface Segregation Principle (ISP)
---------------------------------------------------
-> Clients should not be forced to implement unused methods.
---------------------------------------------------
5️) D — Dependency Inversion Principle (DIP)
---------------------------------------------------
-> High-level modules should depend on abstractions, not concrete classes




 */
