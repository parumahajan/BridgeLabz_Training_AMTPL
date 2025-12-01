/*
--------------------------------------------------------
** LINKED - LIST **

We have individual boxes inside the memory, which we call as Nodes.

These boxes are connected in form of a chain with each other.

It is a Dynamic data structure, which stores the elements in linear fashion.

We can add, delete nodes, and can resize it during the runtime. (just like Vector).

--------------------------------------------------------
THE MAIN DIFFERENCE BETWEEN LL AND ARRAY/VECTOR :

1) MEMORY ADDRESS 

The address of elements in Arrays and Vectors
 are stored in continguous memory 
 (100, 104, 108, ...),

But the Address of Nodes in a Linked list can be
 any value.

LL is already available through STL via <List>.

LL has two main components: 
1) Data
2) Address
-> Using pointers, we store the address of the next node.

If its the last node at the end, then it will store "NULL" as its address.

--------------------------------------------------------
2) INDEX VALUE TRAVERSING

Unlike Arrays and Vectors, we can't access the elements through their index values.

LL can only be tranversed one by one, in linear fashion. 

Hence, its impossible to get O(1) time complexity in case of LL to access a value.

In worst case, we get O(n) time complexity
 
Due to this reason, we maintain an extra pointer, which is the "HEAD POINTER".

It always points to the first node.

If we want the value of any other node, then we'll traverse using the head pointer.

We use Head pointer only, in case of SLL.
But in case of DLL, we use both Head and Tail ptr.

Now, the value that we will take within our LL will be of INTEGER TYPE.

--------------------------------------------------------
** TIME-COMPLEXITY **

* COMMON FOR ALL:
1) Searching/Accesing → O(n)
2) Traversal → O(n)
3) Insert/Delete at head → O(1)
4) Insert/Delete in middle → O(n)
--------------------------------------------------------
5) Insert at tail -> s - O(n) // d,c - O(1)
6) Delete at tail -> s,c - O(n) // d - O(1)
--------------------------------------------------------
* FUNCTIONS IN LL: *

LL has 4 main fns, whenever we pass a value:

1) push_front
-> Inserts a new node in front of the LL

2) push_back
-> Inserts a new node at the end of the LL

3) pop_front
-> Deletes the node present at the start of LL
 
4) pop_back
-> Deletes the node present at the end of the LL

-------------------------------------------------
Now, we'll practice it:

1) push_front
-> The LL starts with NULL values, so head and tail values will be NULL.

When we try to add a value in the LL, then we have 2 cases:

1) Head is NULL (LL is empty & no node is present)
2) Head is NOT-NULL (some nodes are available)

CASE 1:
1) Head is Null (LL is empty)
-> push_front(1) 

Step 1: Create a new node for storing data.
(which is 1)

Step 2: We will add this node to our LL, as this node will become our LL's head.

data = 1
Node* = NULL (next pointing address)

Step 3: Both our Head and Tail pointers will point to this new node.

---------------------------------------------------------
Way 2:
-> Node newNode(val);

THIS CREATES A STATIC OBJECT WITHIN THE MEMORY.

WHAT IT DOES IT, THE MOMENT THE CONTROL COMES OUT FROM PUSH - FRONT(FN CALL), THIS OBJECT WILL GET DELETED.

BUT SINCE WE WANT TO CREATE THE LINKED LIST WITHIN OUR MAIN FN.

WE AVOID USING THIS METHOD.
*/