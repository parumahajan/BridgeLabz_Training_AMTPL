using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    public class Custom_Implementation_Code
    {
        public class Node
        {
            public int data;
            public Node? next;

            public Node(int val)
            {
                data = val;
                next = null;
            }
        }

        public class List
        {
            private Node? head;
            private Node? tail;

            public List()
            {
                head = null;
                tail = null;
            }

            // 1) PUSH FRONT
            public void push_front(int val)
            {
                Node newNode = new Node(val);

                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.next = head;
                    head = newNode;
                }
            }

            // 2) PUSH BACK
            public void push_back(int val)
            {
                Node newNode = new Node(val);

                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    tail!.next = newNode;  // attach at end
                    tail = newNode;        // update tail
                }
            }

            // 3) POP FRONT
            public void pop_front()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_front.");
                    return;
                }

                head = head.next;   // Move head forward

                if (head == null)   // If list became empty
                    tail = null;
            }

            // 4) POP BACK
            public void pop_back()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty. Cannot pop_back.");
                    return;
                }

                // Only one element
                if (head == tail)
                {
                    head = tail = null;
                    return;
                }

                Node temp = head;

                // Move until temp reaches second-last node
                while (temp.next != tail)
                {
                    temp = temp.next!;
                }

                temp.next = null;   // Remove last node
                tail = temp;        // Update tail
            }

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