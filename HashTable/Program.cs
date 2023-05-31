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
        static void Main()
        {
            // Create a LinkedList to store key-value pairs
            LinkedList<MyMapNode<string, int>> linkedList = new LinkedList<MyMapNode<string, int>>();

            string sentence = "To be or not to be";
            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                bool found = false;

                // Check if the word already exists in the linked list
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

            // Display the words and their frequencies
            foreach (MyMapNode<string, int> node in linkedList)
            {
                Console.WriteLine($"Word: {node.Key}, Frequency: {node.Value}");
            }
            Console.ReadKey();
        }
    }
}
