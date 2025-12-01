using System;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    public class _1_Push_Front
    {
        public class Node // This block will contain 2 main components
        {
            public int data;
            public Node? next;
            // ? : "This variable may contain a Node, OR  it may be null.”

            public Node(int val) // Parameterized Constructor
            {
                data = val; // data will store the value
                next = null; // next ptr is null, since its empty for now
                // null will be written in small
            }
        };

        /* 
        Through this above code, we created our nodes.

        Now, in order to COMBINE (LINK) these nodes, we'll create another class. (let's call it List)

        For that, we'll store two main things:
        1) Head 
        2) Tail 
        */

        public class List
        {
            public Node? head;
            public Node? tail;

            public List() // CONSTRUCTOR
            {
                head = tail = null;
            }
            // Since, the LL is Empty in the beginning, so its NULL as no node is present within it.

            public void push_front(int val)
            {   // We'll create a new node from this val (value).

                Node newNode = new Node(val);

                // This "new" keyword creates a Dynamic Object which remains even after the completion of our function call within our memory. 

                if (head == null) // MEANS LL IS EMPTY
                {
                    head = tail = newNode;
                    // We assign the head and tail pointer to the new node that we created.
                }

                /* CASE - 2:

                Now let's suppose another case, where we have to 'push_front' another element (let's say 2) into a Not-Null linked-list.

                -> push_front(2)

                # AS A GOLDEN RULE: 
                We always create a new node, despite the fact whether the linked list is empty or not.

                1) Node* newNode = new Node(val); 
                This new node 2 will be placed in front of node 1, and we'll establish a connection between both the nodes.

                2) newNode.next = head;
                (instead of '->', in C# '.' is used)

                The next pointer of newNode 2 will be pointing to head pointer, which is pointing to the Node 1. 

                In this way, we'll establish the connection.

                Since, now we have push_fronted new node 2, and its the first node now, so we'll point Head pointer towards it. 

                3) head = newNode;


                For implementing this, we'll introduce an "else-condition", within our "push_front" fn.
                */

                else // a node is already present, and above that we are introducing another node (by pushin it)
                {
                    newNode.next = head;
                    head = newNode;
                }
            }
            // ---------------------------------------------------
            // Now, to Print the linked list, we'll create a "printLL" fn.
            public void printLL()
            {
                // Here, we will create another pointer, named "Temp" pointer.

                // It's initial position will be equal to the position of head pointer.

                Node? temp = head;

                // Now, in order to traverse throught the LL in order to print it, We'll create a loop, till our temp's value becomes NULL.

                while (temp != null)
                {
                    Console.WriteLine(temp.data + " ");
                    // We'll print the value (element) whichever temp is pointing to.

                    temp = temp.next;
                    // We'll update temp to the next position.
                }
            }
        }

        /*
        --------------------------------------------------------
        Q) WHY DID WE CREATE TEMP, WHEN WE COULD'VE JUST USE "HEAD" POINTER ?

        -> The reason why we didn't traverse using the Head pointer is because, in SLL, only forward traversal is possible, and not the backward traversal.

        Due to this, we create a copy of "Head" pointer as "Temp" pointer, and traverse the LL using it.

        In this way, we preserve the Head pointer.
        --------------------------------------------------------
         */

        public static void Main(string[] args)
        {
            List ll = new List();
            // This will create a ll within our main fn.

            ll.push_front(1);
            ll.push_front(2);
            ll.push_front(3);

            ll.printLL();
        }
    }
}