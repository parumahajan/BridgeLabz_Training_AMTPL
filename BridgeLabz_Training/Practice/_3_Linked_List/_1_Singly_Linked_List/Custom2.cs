using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    internal class Custom2
    {
        public class Employee
        {
            public int Id { get; set; }        // Unique employee id
            public string Name { get; set; }   // Employee name
            public string Department { get; set; }
            public double Salary { get; set; }

            public Employee(int id, string name, string department, double salary)
            {
                Id = id;
                Name = name;
                Department = department;
                Salary = salary;
            }

            public override string ToString()
            {
                return $"[Id: {Id}, Name: {Name}, Dept: {Department}, Salary: {Salary}]";
            }
        }

        // -------------------------------------------------------------
        // Node class: A single node of a singly linked list
        // -------------------------------------------------------------
        public class Node
        {
            public Employee Data;   // The employee stored inside this node
            public Node? Next;      // Pointer to next node

            public Node(Employee emp)
            {
                Data = emp;
                Next = null;
            }
        }

        // -------------------------------------------------------------
        // Custom Singly Linked List (NO built-in List<T> or LinkedList<T>)
        // -------------------------------------------------------------
        public class CustomLinkedList
        {
            private Node? head;   // First node
            private Node? tail;   // Last node
            public int Count { get; private set; }

            public CustomLinkedList()
            {
                head = null;
                tail = null;
                Count = 0;
            }

            // ---------------------------------------------------------
            // AddFirst(Employee emp)
            // Inserts a new employee at the start of the list
            // ---------------------------------------------------------
            public void AddFirst(Employee emp)
            {
                Node newNode = new Node(emp);

                if (head == null)    // If list is empty
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head; // Link new node to current head
                    head = newNode;      // Update head
                }

                Count++;
            }

            // ---------------------------------------------------------
            // AddLast(Employee emp)
            // Inserts a new employee at the end of the list
            // ---------------------------------------------------------
            public void AddLast(Employee emp)
            {
                Node newNode = new Node(emp);

                if (head == null)   // If list is empty
                {
                    head = tail = newNode;
                }
                else
                {
                    tail!.Next = newNode; // attach new node to tail
                    tail = newNode;       // update tail pointer
                }

                Count++;
            }

            // ---------------------------------------------------------
            // Remove(int employeeId)
            // Removes the first employee whose Id matches employeeId
            // Returns true if removed, false if not found
            // ---------------------------------------------------------
            public bool Remove(int employeeId)
            {
                if (head == null) return false; // empty list

                // Case 1: head is the employee to be removed
                if (head.Data.Id == employeeId)
                {
                    head = head.Next; // move head forward

                    if (head == null) // if list becomes empty
                        tail = null;

                    Count--;
                    return true;
                }

                // Case 2: search in the middle or end
                Node prev = head;
                Node? cur = head.Next;

                while (cur != null)
                {
                    if (cur.Data.Id == employeeId)
                    {
                        prev.Next = cur.Next; // remove node

                        if (cur == tail)      // if removing last node
                            tail = prev;

                        Count--;
                        return true;
                    }

                    prev = cur;
                    cur = cur.Next;
                }

                return false; // employee not found
            }

            // ---------------------------------------------------------
            // Search(string name)
            // Returns all employees whose name matches (case-insensitive)
            // ---------------------------------------------------------
            public Employee[] Search(string name)
            {
                int matches = 0;
                Node? temp = head;

                // 1st pass → count matches
                while (temp != null)
                {
                    if (temp.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        matches++;
                    temp = temp.Next;
                }

                if (matches == 0)
                    return new Employee[0];

                // 2nd pass → store matching employees
                Employee[] result = new Employee[matches];
                int index = 0;
                temp = head;

                while (temp != null)
                {
                    if (temp.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        result[index++] = temp.Data;

                    temp = temp.Next;
                }

                return result;
            }

            // ---------------------------------------------------------
            // Display()
            // Prints all employees from head → tail
            // ---------------------------------------------------------
            public void Display()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty.");
                    return;
                }

                Node? temp = head;
                while (temp != null)
                {
                    Console.WriteLine(temp.Data);
                    temp = temp.Next;
                }
            }
        }

        // -------------------------------------------------------------
        // DEMO PROGRAM — Insert 5 employees and perform all operations
        // -------------------------------------------------------------
        public class Program
        {
            public static void Main(string[] args)
            {
                CustomLinkedList employees = new CustomLinkedList();

                // Insert 5 employees
                employees.AddLast(new Employee(101, "Alice", "HR", 55000));
                employees.AddLast(new Employee(102, "Bob", "IT", 70000));
                employees.AddFirst(new Employee(103, "Carol", "Finance", 65000));
                employees.AddLast(new Employee(104, "Dave", "Marketing", 60000));
                employees.AddFirst(new Employee(105, "Eve", "Sales", 58000));

                Console.WriteLine("---- After inserting 5 Employees ----");
                employees.Display();
                Console.WriteLine($"Count = {employees.Count}\n");

                // Search employees by name
                Console.WriteLine("---- Searching for 'Bob' ----");
                var found = employees.Search("Bob");

                if (found.Length == 0)
                    Console.WriteLine("No employee found with name 'Bob'");
                else
                {
                    Console.WriteLine("Search results:");
                    foreach (var emp in found)
                        Console.WriteLine(emp);
                }

                Console.WriteLine();

                // Remove an employee
                Console.WriteLine("---- Removing Employee with Id = 103 ----");
                bool removed = employees.Remove(103);
                Console.WriteLine(removed ? "Removed successfully." : "Employee not found.");
                Console.WriteLine();

                Console.WriteLine("---- List after removal ----");
                employees.Display();
                Console.WriteLine($"Count = {employees.Count}\n");

                // Demonstrate AddFirst and AddLast again
                Console.WriteLine("---- AddFirst and AddLast Demo ----");
                employees.AddFirst(new Employee(106, "Frank", "R&D", 72000)); // new head
                employees.AddLast(new Employee(107, "Grace", "Support", 52000)); // new tail

                employees.Display();
                Console.WriteLine($"Count = {employees.Count}\n");

                // Add duplicate names and search again
                Console.WriteLine("---- Adding another 'Alice' ----");
                employees.AddLast(new Employee(108, "Alice", "Contract", 50000));

                var alices = employees.Search("Alice");
                Console.WriteLine($"Found {alices.Length} employee(s) named 'Alice':");
                foreach (var e in alices)
                    Console.WriteLine(e);

                Console.WriteLine("\n---- Final List ----");
                employees.Display();
                Console.WriteLine($"Final Count = {employees.Count}");
            }
        }
    }
}