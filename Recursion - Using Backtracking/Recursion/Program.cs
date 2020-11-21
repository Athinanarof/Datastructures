using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindPairOfIntergersWithDifferenceK(new int[] { 1, 7, 5, 9, 2, 12, 3 }, 2);
            //PrintAllPosibleValuesForFormula();
            
        }

        #region Fibonacci
        public static int Fibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n -2);
        }
        #endregion

        #region FindPairOfIntergersWithDifferenceK
        public static int FindPairOfIntergersWithDifferenceK(int[] arrayOfNumbers, int difference)
        {
            HashSet<int> hash = InsertInHashSet(arrayOfNumbers);

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                int currentNumber = arrayOfNumbers[i];
                int pendingNumber = currentNumber - difference;
                if (hash.Contains(pendingNumber))
                {
                    Console.WriteLine("{" + currentNumber + " , " + pendingNumber + "}");
                }
            }
            return 0;
        }
        public static HashSet<int> InsertInHashSet(int[] arrayOfNumbers)
        {
            HashSet<int> hash = new HashSet<int>();
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                hash.Add(arrayOfNumbers[i]);
            }
            return hash;
        }
        #endregion

        #region a^3 + b^3 = c^3 + d^3
        public static void PrintAllPosibleValuesForFormula()
        {
            int totalPairs = 0;
            Dictionary<double, Tuple<int, int>> pairs = new Dictionary<double, Tuple<int, int>>();
            for (int a = 1; a <= 1000; a++)
            {
                for (int b = a; b <= 1000; b++)
                {
                    double cube = Math.Pow(a, 3) + Math.Pow(b, 3);
                    if (!pairs.ContainsKey(cube))
                    {
                        pairs.Add(cube, new Tuple<int, int>(a, b));
                    }
                }
            }

            for (int c = 1; c <= 1000; c++)
            {
                for (int d = 1; d < 1000; d++)
                {
                    double cube = Math.Pow(c, 3) + Math.Pow(d, 3);
                    if (pairs.ContainsKey(cube))
                    {
                        totalPairs++;
                        Console.WriteLine(pairs[cube].ToValueTuple() + " == " + "(" + c + ", " + d + ")");
                    }

                }
            }
            Console.WriteLine(totalPairs);
            Console.ReadLine();
        }
        #endregion
    }
}
