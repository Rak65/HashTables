using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MyMapNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    class Program
    {
        static void Main(String[] args)
        {
            // Create an array of LinkedLists to store words at each index
            LinkedList<MyMapNode<string, int>>[] hashTable = new LinkedList<MyMapNode<string, int>>[100];

            string phrase = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = phrase.Split(' ');

            foreach (string word in words)
            {
                // Get the index for the word using the hash code
                int index = Math.Abs(word.GetHashCode() % 100);

                // Create a new LinkedList at the index if it doesn't exist
                if (hashTable[index] == null)
                {
                    hashTable[index] = new LinkedList<MyMapNode<string, int>>();
                }

                LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];
                bool found = false;

                // Check if the word already exists in the linked list at the index
                foreach (MyMapNode<string, int> node in linkedList)
                {
                    if (node.Key.Equals(word))
                    {
                        // If the word is found, increment its frequency count
                        node.Value += 1;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // If the word is not found, add a new node with frequency count 1
                    MyMapNode<string, int> newNode = new MyMapNode<string, int>
                    {
                        Key = word,
                        Value = 1
                    };
                    linkedList.AddLast(newNode);
                }
            }

            // Remove the word "avoidable" from the hash table
            RemoveWordFromHashTable(hashTable, "avoidable");

            // Display the words and their frequencies
            for (int i = 0; i < hashTable.Length; i++)
            {
                LinkedList<MyMapNode<string, int>> linkedList = hashTable[i];
                if (linkedList != null)
                {
                    foreach (MyMapNode<string, int> node in linkedList)
                    {
                        Console.WriteLine($"Word: {node.Key}, Frequency: {node.Value}");
                    }
                }
            }
            Console.ReadKey();
        }

        static void RemoveWordFromHashTable(LinkedList<MyMapNode<string, int>>[] hashTable, string word)
        {
            // Get the index for the word using the hash code
            int index = Math.Abs(word.GetHashCode() % 100);

            LinkedList<MyMapNode<string, int>> linkedList = hashTable[index];
            if (linkedList != null)
            {
                // Find and remove the node with the specified word from the linked list
                LinkedListNode<MyMapNode<string, int>> currentNode = linkedList.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(word))
                    {
                        linkedList.Remove(currentNode);
                        break;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
