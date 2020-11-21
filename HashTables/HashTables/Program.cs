using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    /*
     * Constraints
     * 1 <= N <= 10^5           N = number of colleagues, 100,000
     * 1 <= RollNumber <= 10^9  RollNumber of colleague   1,000,000,000
     *                              
     *                          NOTE: in order to set all the RollNumbers in the array of N elements I
     *                                will need to divide by 10,000. If I want a prime number to avoid collisions
     *                                it will be 10,003, smallest prime number.
     *                        
     * 1 <= |Name| <= 25        Name of colleague
     * 1 <= q <= 10^4           q = number of queries     10,000
     * 1 <= x <= 10^9           x = roll number of student that Monk wants to know name     1,000,000,000
     * 
     * SAMPLE INPUT
     *  5
        1 vasya
        2 petya
        3 kolya
        4 limak
        5 illya
        2
        1
        2

      SAMPLE OUTPUT
          vasya
          petya
    */
    class Program
    {
        struct Node
        {
            public int Key;
            public string Value;
        }

        static int minPrimeNumber = 100003;
        static Node[] hashTable = new Node[minPrimeNumber];

        public static int hashFunction(int rollNumber)
        {
            return rollNumber % minPrimeNumber;
        }

        public static void add(string name, int rollNumber)
        {
            int index = hashFunction(rollNumber);
            while (hashTable[index].Key != -1)
            {
                index = (index + 1) % minPrimeNumber;
            }
            hashTable[index].Key = rollNumber;
            hashTable[index].Value = name;
        }

        public static string get(int rollNumber)
        {
            int index = hashFunction(rollNumber);
            while (hashTable[index].Key != rollNumber)
            {
                index = index + 1 % minPrimeNumber; 
            }

            return hashTable[index].Value;
        }
        static void Main(string[] args)
        {
            int q_numberOfQueries = 10000;

            // initialization
            for (int i = 0; i < minPrimeNumber; i++)
            {
                hashTable[i].Key = -1;
                hashTable[i].Value = string.Empty;
            }

            string[] studentsNames = 
            {
                "vasya",
                "petya",
                "kolya",
                "limak",
                "illya"
            };

            for (int i = 0; i < studentsNames.Length; i++)
            {
                add(studentsNames[i], 1000000000 + i);
            }

            for (int i = 0; i < q_numberOfQueries; i++)
            {
                get(1000000002);

            }
        }
    }
}
