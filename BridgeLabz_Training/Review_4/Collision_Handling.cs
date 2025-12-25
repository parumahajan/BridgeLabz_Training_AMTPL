/*
---------------------------------------
Custom Hash Table (Without Dictionary)
---------------------------------------
Implement a Custom Hash Table for Storing Emails

Requirements: Use an array of Linked Lists for collision handling (Chaining).

Hash function:  hash = sum of ASCII chars % arrayLength

Methods:

1) Insert(string email)

2) Search(string email)

3) Delete(string email)

Validate email using Regex before inserting.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BridgeLabz_Training.Review_4
{
    public class Collision_Handling
    {
        // Node for Linked List
        public class Node
        {
            public string Email; // data 
            public Node? Next;   // next node address

            public Node(string email) // Parameterized constructor
            {
                Email = email;
                Next = null;
            }
        }

        // Custom hash table to store emails
        public class EmailHashTable
        {
            private Node?[] buckets; // array of linked lists
            private int capacity; // size of the buckets array (represents the arrayLength)

            private Regex emailRegex; // regex for email validation


            public EmailHashTable(int capacity = 10) // Parameterized constructor
            {
                if (capacity <= 0)
                {
                    throw new ArgumentException("Capacity must be > 0");
                }

                this.capacity = capacity;
                buckets = new Node?[capacity];

                emailRegex = new Regex(@"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$");
            }

            // To compute the hash function
            private int ComputeHash(string email)
            {
                int sum = 0;
                foreach (char c in email)
                {
                    sum += c;
                }

                return Math.Abs(sum) % capacity;
                //sum of ASCII chars % capacity (arrayLength)
            }

            // To validate email format using regex
            public bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                return emailRegex.IsMatch(email);
            }


            // Insertion of email
            public bool Insert(string email)
            {
                if (!IsValidEmail(email))
                {
                    Console.WriteLine($"Invalid email format: '{email}'");
                    // if the email is invalid, then it displays this message, and returns false
                    return false;
                }

                int index = ComputeHash(email); // to compute hash index

                if (buckets[index] == null) // if the bucket is empty, then we can insert directly
                {
                    buckets[index] = new Node(email);
                    return true;
                }

                // To traverse the chain in order to check duplicates
                Node current = buckets[index]!;

                while (true)
                {
                    if (string.Equals(current.Email, email, StringComparison.OrdinalIgnoreCase))
                    {
                        // if it is duplicate, then display this message
                        Console.WriteLine($"Email already exists: '{email}'");

                        return false;
                    }

                    if (current.Next == null)
                    {
                        break;
                    }
                    current = current.Next;
                }

                current.Next = new Node(email); // insert at the end of the chain
                return true;
            }

            // To Search for email
            public bool Search(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                int index = ComputeHash(email);
                Node? current = buckets[index]; // to get the head of the chain

                while (current != null)
                {
                    if (string.Equals(current.Email, email, StringComparison.OrdinalIgnoreCase)) // to compare the emails
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            // To Delete the email
            public bool Delete(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                int index = ComputeHash(email); // compute hash index

                Node? current = buckets[index]; // head of the chain
                Node? prev = null; // to keep track of previous node

                while (current != null)
                {
                    if (string.Equals(current.Email, email, StringComparison.OrdinalIgnoreCase)) // to compare the emails
                    {
                        if (prev == null)
                        {
                            buckets[index] = current.Next; // to remove head of chain,and update head to next node
                        }
                        else
                        {
                            prev.Next = current.Next; // update previous node's next reference
                        }
                        return true;
                    }
                    prev = current; // it updates previous node
                    current = current.Next; // moves to next node
                }

                return false; // not found
            }


            // To print the hash table
            public void PrintTable()
            {
                Console.WriteLine("Hash Table Buckets:");
                for (int i = 0; i < capacity; i++)
                {
                    Console.Write($"[{i}]: "); // to print the bucket index
                    Node? current = buckets[i];

                    if (current == null)
                    {
                        Console.WriteLine("(empty)");
                        continue;
                    }

                    while (current != null)
                    {
                        Console.Write(current.Email); // to print the email

                        if (current.Next != null)
                        {
                            Console.Write(" "); // in order to separate the emails present in the same bucket
                        }

                        current = current.Next; // to move to next node
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void Main(string[] args)
        {

            EmailHashTable table = new EmailHashTable(capacity: 3);

            string[] emailsToInsert = new string[] // array of emails to insert
            {
                "pranavmahajan619@gmail.com",       // valid email
                "parumahajan3000@gmail.com",        // valid email
                "invalid-email",                    // invalid email
                "pranavmahajan619@gmail.com",       // duplicate email
            };

            Console.WriteLine("Inserting emails:");
            foreach (var em in emailsToInsert)
            {
                bool inserted = table.Insert(em);
                Console.WriteLine($"{em} -> {(inserted ? "Inserted" : "Skipped (since its Duplicate)")}\n");
            }
            Console.WriteLine();

            table.PrintTable();
            Console.WriteLine();

            // To Search for email
            Console.WriteLine("Searching for emails:");
            string[] searches = { "pranavmahajan619@gmail.com", "invalid-email", "parumahajan3000@gmail.com" };

            foreach (var s in searches)
            {
                Console.WriteLine($"{s} found? {table.Search(s)}");
            }
            Console.WriteLine();

            // To Delete the email
            Console.WriteLine("Deleting the invalid emails:");
            Console.WriteLine($"Deleting 'invalid-email' : {table.Delete("invalid-email'")}");

            Console.WriteLine();

            table.PrintTable();
            Console.WriteLine();

            // Insert again after deletion
            Console.WriteLine("Inserting after making deletions:\n");

            table.Insert("pm9969@srmist.edu.in");
            table.PrintTable();
        }
    }
}