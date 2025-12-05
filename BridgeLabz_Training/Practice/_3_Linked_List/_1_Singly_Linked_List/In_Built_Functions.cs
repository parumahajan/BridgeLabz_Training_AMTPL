using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz_Training.Practice._3_Linked_List._1_Singly_Linked_List
{
    public class In_Built_Functions
    {
        public static void Main(string[] args)
        {
            // Create a LinkedList of integers
            LinkedList<int> list = new LinkedList<int>();

            // ----------------------------------------------------------
            // 1) AddFirst(T value)  → Inserts at the beginning
            // ----------------------------------------------------------
            list.AddFirst(10); // List: 10
            list.AddFirst(5);  // List: 5 → 10

            // ----------------------------------------------------------
            // 2) AddLast(T value)  → Inserts at the end
            // ----------------------------------------------------------
            list.AddLast(20);  // List: 5 → 10 → 20
            list.AddLast(30);  // List: 5 → 10 → 20 → 30

            // ----------------------------------------------------------
            // 3) AddBefore(LinkedListNode<T> node, T value)
            // Add value BEFORE a specific node
            // ----------------------------------------------------------
            LinkedListNode<int>? node20 = list.Find(20); 
            // finds node containing 20

            if (node20 != null)
            {
                list.AddBefore(node20, 15); // List: 5 → 10 → 15 → 20 → 30
            }

            // ----------------------------------------------------------
            // 4) AddAfter(LinkedListNode<T> node, T value)
            // Add value AFTER a specific node
            // ----------------------------------------------------------
            if (node20 != null)
            {
                list.AddAfter(node20, 25); // List: 5 → 10 → 15 → 20 → 25 → 30
            }

            // ----------------------------------------------------------
            // Print using foreach traversal
            // ----------------------------------------------------------
            Console.WriteLine("List after insertions:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // ----------------------------------------------------------
            // 5) Remove(T value)  → Removes first occurrence
            // ----------------------------------------------------------
            list.Remove(15); // List: 5 → 10 → 20 → 25 → 30

            // ----------------------------------------------------------
            // 6) RemoveFirst()  → Delete first node
            // ----------------------------------------------------------
            list.RemoveFirst(); // Removes 5 → List: 10 → 20 → 25 → 30

            // ----------------------------------------------------------
            // 7) RemoveLast()  → Delete last node
            // ----------------------------------------------------------
            list.RemoveLast(); // Removes 30 → List: 10 → 20 → 25

            Console.WriteLine("\nList after removals:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // ----------------------------------------------------------
            // 8) Find(T value)  → Returns FIRST matching node
            // ----------------------------------------------------------
            var found20 = list.Find(20);
            if (found20 != null)
                Console.WriteLine($"\nFind(20): Node found with value = {found20.Value}");

            // ----------------------------------------------------------
            // 9) FindLast(T value)  → Returns LAST matching node
            // ----------------------------------------------------------
            // For demo, add duplicate values
            list.AddLast(20);
            list.AddLast(20);

            var foundLast20 = list.FindLast(20);
            if (foundLast20 != null)
                Console.WriteLine($"FindLast(20): Last node value = {foundLast20.Value}");

            Console.WriteLine("\nList after adding duplicates:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // ----------------------------------------------------------
            // 10) Clear()  → Removes all elements
            // ----------------------------------------------------------
            list.Clear();

            Console.WriteLine("\nList after Clear():");
            Console.WriteLine("Count = " + list.Count);  // Should be 0
        }
    }
}