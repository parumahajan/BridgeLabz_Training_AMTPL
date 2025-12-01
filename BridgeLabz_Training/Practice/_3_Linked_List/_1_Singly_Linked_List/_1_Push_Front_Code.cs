using System;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    public class _1_Push_Front_Code
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

            ll.printLL();
        }
    }
}