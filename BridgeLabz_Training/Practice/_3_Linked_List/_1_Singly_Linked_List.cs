using System;

namespace BridgeLabz_Training.Practice._3_Linked_List
{
    public class _1_Singly_Linked_List
    {
        class Node // block
        {
        public: // 2 main components
            int data;
            Node* next;

            Node(int val) // Constructor
            {
                data = val;
                next = NULL;
            }
        };

        /* 
        Through this above code, we created our nodes.

        Now, in order to combine these nodes, we'll create another class. (let's call it List)

        For that, we'll store two main things:
        1) Head 
        2) Tail 
        */

        class List
        {
            Node* head;
            Node* tail;
            // we are not passing these values, so we'll face no issues, even if they are kept private

        public:
            List()
            {
                head = tail = NULL;
            }
            // Because the LL which is created in beginning is Empty, and there's no node present within it.
            void push_front(int val)
            {
                // we'll create a new node from this value
                
                // There are 2 ways of creating a node with val

                // WAY 1 -
                Node* newNode = new Node(val);  

                // NEW KEYWORD CREATES A DYNAMIC OBJECT WHICH REMAINS EVEN AFTER THE COMPLETION OF OUR FN CALL WITHIN OUR MEMORY.

                // Way 2 - 
                Node newNode(val);
                // THIS CREATES A STATIC OBJECT WITHIN THE MEMORY.

                // WHAT IT DOES IT, THE MOMENT THE CONTROL COMES OUT FROM PUSH-FRONT (FN CALL), THIS OBJECT WILL GET DELETED.

                // BUT SINCE WE WANT TO CREATE THE LINKED LIST WITHIN OUR MAIN FN.

                if(head == NULL)
                {
                    head = tail = newNode;
                }
            }
        };

        public static void Main(string[] args)
        {
            List ll;
        }
    }
}