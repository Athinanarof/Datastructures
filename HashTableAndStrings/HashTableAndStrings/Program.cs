using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndStrings
{
    class Program
    {
        public static string[] strings = new string[] { "abcdef", "bcdefa", "cdefab", "defabc" };
        public static string[] hashTable = new string[50];

        #region SimplyInsertingValuesInHashTable
        public static void InsertValuesInHashTable()
        {
            string currentString = String.Empty;
            for (int i = 0; i < strings.Length; i++)
            {
                currentString = strings[i];
                int newIndex = HashFunction(currentString);
                hashTable[newIndex] = currentString;
            }
        }
        public static int HashFunction(string key)
        {
            int index = 0;
            int asciiValue = 0;
            int asciiPlusPosition = 0;

            for (int i = 0; i < key.Length; i++)
            {
                asciiValue = (int)key[i];
                asciiPlusPosition = asciiValue * (i + 1);
                index += asciiPlusPosition;
            }

            index = index % 50;
            return index;
        }
        #endregion

        #region CountFrecuenciesOfLettersInString
        public static void CountFrecuenciesOfLettersInString()
        {
            int[] lettersFrecuencyHashTable = new int[26];
            string word = "ababcd";
            for (int i = 0; i < word.Length; i++)
            {
                int index = Frecuencies_HashFunction(word[i]);
                lettersFrecuencyHashTable[index]++;
            }

        }
        public static int Frecuencies_HashFunction(char key)
        {
            return (key - 'a');
        }
        #endregion
        static void Main(string[] args)
        {
            //InsertValuesInHashTable();
            //CountFrecuenciesOfLettersInString();
        }
    }
}
