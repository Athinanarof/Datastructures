using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndCollisionsSeparateChaining
{
    public class ListNode
    {
        public string value;
        public ListNode next;
        public ListNode(string value)
        {
            this.value = value;
            next = null;
        }
    }
    
    // Asumption hash function will return an interger from 0 to 19
    class Program
    {
        //Hashtable hash = new Hashtable();
        //Dictionary<int, ListNode> hashTable = new Dictionary<int, ListNode>();

        static ListNode[] hashTable = new ListNode[20];
        static int hashTableSize = 20;
        public static int HashFunction(string key)
        {
            int index = 0;
            for (int i = 0; i < key.Length; i++)
            {
                index = (int)key[i] * (i + 1);
            }
            return index % hashTableSize;
        }

        public static void Insert(string word)
        {
            int index = HashFunction(word);
            PushNode(index, word);
        }

        public static void PushNode(int index, string word)
        {
            if (hashTable[index] != null)
            {
                hashTable[index].next = new ListNode(word);
            }
            else
            {
                hashTable[index] = new ListNode(word);
            }
        }

        public static void Search(string word)
        {
            int index = HashFunction(word);

            if (hashTable[index] != null)
            {
                ListNode node = (ListNode)hashTable[index];
                while (node != null || node.value != word)
                {
                    node = hashTable[index].next;
                }
                if (node.value == word)
                {
                    Console.WriteLine("We found the word " + word);
                }
            }
        }
        static void Main(string[] args)
        {
            string[] words = { "HackerEarth", "CodeMonk", "Tutorial", "Hashing" };
            for (int i = 0; i < words.Length; i++)
            {
                Insert(words[i]);                
            }
            Search("Gatitos peludos");
            Console.ReadKey();

        }
    }
}
