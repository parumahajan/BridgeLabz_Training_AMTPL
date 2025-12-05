using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    public class Custom_Implementation
    {

        // Node represents a single element of the linked list
        public class Node
        {
            public int data;   // value stored inside the node
            public Node? next; // reference to the next node

            public Node(int val)
            {
                data = val;
                next = null;   // next is null by default
            }
        }

        // List class manages the entire linked list
        public class List
        {
            private Node? head;   // pointer to first node
            private Node? tail;   // pointer to last node

            public List()
            {
                head = null;     // initially list is empty
                tail = null;
            }

            // ------------------------------------------------
            // 1) PUSH FRONT — Insert at the beginning
            // ------------------------------------------------
            public void push_front(int val)
            {
                Node newNode = new Node(val);   // create new node

                // If list is empty, new node becomes both head and tail
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    // Point new node's next to old head
                    newNode.next = head;

                    // Move head to new node
                    head = newNode;
                }
            }

            // ------------------------------------------------
            // 2) PUSH BACK — Insert at the end
            // ------------------------------------------------
            public void push_back(int val)
            {
                Node newNode = new Node(val); // create new node

                // If list is empty, new node becomes both head and tail
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    // Attach new node at end of list
                    tail!.next = newNode;

                    // Move tail to new node
                    tail = newNode;
                }
            }

            // ----------------------------------------------------------
            // 3) POP FRONT — Remove first element
            // ----------------------------------------------------------
            public void pop_front()
            {
                // Cannot remove from empty list
                if (head == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_front.");
                    return;
                }

                // Move head to next node (removes first node)
                head = head.next;

                // If list becomes empty after removal, set tail to null
                if (head == null)
                {
                    tail = null;
                }
            }

            // ----------------------------------------------------------
            // 4) POP BACK — Remove last element
            // ----------------------------------------------------------
            public void pop_back()
            {
                // Cannot remove from empty list
                if (head == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_back.");
                    return;
                }

                // If there's only 1 node
                if (head == tail)
                {
                    head = tail = null;   // list becomes empty
                    return;
                }

                // Otherwise, find second last node
                Node temp = head;

                // Stop when temp reaches the node just before tail
                while (temp.next != tail)
                {
                    temp = temp.next!;
                }

                // Remove last node
                temp.next = null;

                // Update tail to second-last node
                tail = temp;
            }

            // ------------------------------------------------
            // PRINT — Display linked list
            // ------------------------------------------------
            public void printLL()
            {
                Node? temp = head;

                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            List ll = new List();

            ll.push_front(1);
            ll.push_front(2);
            ll.push_front(3);

            ll.push_back(10);
            ll.push_back(20);

            ll.printLL();  // Output: 3 2 1 10 20

            ll.pop_front();
            ll.printLL();  // Output: 2 1 10 20

            ll.pop_back();
            ll.printLL();  // Output: 2 1 10
        }
    }
}