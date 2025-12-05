using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._3_Linked_List._2_Doubly_Linked_list
{
    internal class Custom_Imp
    {
        // Node for doubly linked list: stores value and links to both neighbors
        public class Node
        {
            public int data;   // the value stored in node
            public Node? prev; // reference to previous node
            public Node? next; // reference to next node

            public Node(int val)
            {
                data = val;
                prev = null;   // no previous by default
                next = null;   // no next by default
            }
        }

        // Doubly linked list container with head and tail pointers
        public class List
        {
            private Node? head; // points to first node
            private Node? tail; // points to last node

            public List()
            {
                head = null;    // initially empty list
                tail = null;
            }

            // ----------------------------------------------------------
            // 1) PUSH FRONT — Insert a new node at the beginning
            // ----------------------------------------------------------
            public void push_front(int val)
            {
                // Create new node with given value
                Node newNode = new Node(val);

                // If list is empty, new node becomes both head and tail
                if (head == null)
                {
                    head = tail = newNode;
                    return;
                }

                // Link the current head as next of new node
                newNode.next = head;

                // Current head's prev should point back to new node
                head.prev = newNode;

                // Move head pointer to new node
                head = newNode;
            }

            // ----------------------------------------------------------
            // 2) PUSH BACK — Insert a new node at the end
            // ----------------------------------------------------------
            public void push_back(int val)
            {
                // Create new node
                Node newNode = new Node(val);

                // If list is empty, new node becomes head and tail
                if (tail == null) // same as head == null
                {
                    head = tail = newNode;
                    return;
                }

                // Attach new node after current tail
                tail.next = newNode;

                // New node's prev points back to old tail
                newNode.prev = tail;

                // Update tail to new node
                tail = newNode;
            }

            // ----------------------------------------------------------
            // 3) POP FRONT — Remove the first node
            // ----------------------------------------------------------
            public void pop_front()
            {
                // If list is empty, nothing to remove
                if (head == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_front.");
                    return;
                }

                // If only one node exists
                if (head == tail)
                {
                    head = tail = null; // list becomes empty
                    return;
                }

                // Move head to next node
                head = head.next;

                // previous of new head must be null (disconnect old head)
                if (head != null)
                    head.prev = null;
            }

            // ----------------------------------------------------------
            // 4) POP BACK — Remove the last node
            // ----------------------------------------------------------
            public void pop_back()
            {
                // If list is empty, nothing to remove
                if (tail == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_back.");
                    return;
                }

                // If only one node exists
                if (head == tail)
                {
                    head = tail = null; // list becomes empty
                    return;
                }

                // Move tail to previous node
                tail = tail.prev;

                // next of new tail must be null (disconnect old tail)
                if (tail != null)
                    tail.next = null;
            }

            // ----------------------------------------------------------
            // PRINT FORWARD — traverse from head to tail and print values
            // ----------------------------------------------------------
            public void printForward()
            {
                Node? temp = head;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }

            // ----------------------------------------------------------
            // PRINT BACKWARD — traverse from tail to head and print values
            // (useful to verify prev pointers are correct)
            // ----------------------------------------------------------
            public void printBackward()
            {
                Node? temp = tail;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.prev;
                }
                Console.WriteLine();
            }
        }

        // Demo usage
        public static void Main(string[] args)
        {
            List dll = new List();

            // Push elements at front
            dll.push_front(1); // list: 1
            dll.push_front(2); // list: 2 1
            dll.push_front(3); // list: 3 2 1

            // Push elements at back
            dll.push_back(10); // list: 3 2 1 10
            dll.push_back(20); // list: 3 2 1 10 20

            Console.WriteLine("Print forward (head -> tail):");
            dll.printForward();    // Expected: 3 2 1 10 20

            Console.WriteLine("Print backward (tail -> head):");
            dll.printBackward();   // Expected: 20 10 1 2 3

            // Remove from front
            dll.pop_front();       // removes 3 -> list: 2 1 10 20
            Console.WriteLine("After pop_front:");
            dll.printForward();    // Expected: 2 1 10 20

            // Remove from back
            dll.pop_back();        // removes 20 -> list: 2 1 10
            Console.WriteLine("After pop_back:");
            dll.printForward();    // Expected: 2 1 10

            // Final backward check
            Console.WriteLine("Final backward:");
            dll.printBackward();   // Expected: 10 1 2
        }
    }
}