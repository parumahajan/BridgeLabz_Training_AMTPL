using System;

namespace BridgeLabz_Training.Practice._3_Linked_List
{
    public class Practice
    {
        public class Node // this block will contain 2 major things.
        {
            public int data;
            public Node? next;

            public Node(int val) // Parameterized Constructor
            {
                data = val;
                next = null;
            }

        };

        public class List // To link the nodes
        {
            public Node? head;
            public Node? tail;

            public List() // Constructor
            {
                head = tail = null; // since LL is empty
            }

            public void push_front(int val) // to push_front the value
            {
                Node newNode = new Node(val); // we created a New Node

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


        };





    }
}