using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix90Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // bidimentional array
            int[,] matrixA = new int[5, 5]
            {
                { 1, 2, 3,4,5},
                { 6,7,8,9,10 },
                {11,12,13,14,15},
                {16,17,18,19,20},
                {21,22,23,24,25}
            };
            // jagged array
            int[][] matrix = new int[5][];
            
                matrix[0] = new int[]{ 1, 2, 3,4,5};
                matrix[1] = new int[]{ 6,7,8,9,10 };
                matrix[2] = new int[]{11,12,13,14,15};
                matrix[3] = new int[]{16,17,18,19,20};
                matrix[4] = new int[]{21,22,23,24,25};
            
            RotateMatrix(matrix);
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[0].Length; column++)
                {
                    Console.Write(matrix[row][column] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        // Using layers approach
        static void RotateMatrix(int[][] matrix)
        {
            int matrix_leng = matrix.Length;
            // profundidad, que tan hacia el centro nos movemos
            int depth = matrix_leng / 2;

            for (int layer = 0; layer < depth; layer++)
            {
                int first = layer;
                int last = matrix_leng - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset_IterationAlreadyDoneInLayer = i - first;

                    int top = matrix[first][i]; // save top

                    // left -> top
                    matrix[first][i] = 
                        matrix[last - offset_IterationAlreadyDoneInLayer][first];

                    // bottom -> left
                    matrix[last - offset_IterationAlreadyDoneInLayer][first] = 
                        matrix[last][last - offset_IterationAlreadyDoneInLayer];

                    // right -> bottom
                    matrix[last][last - offset_IterationAlreadyDoneInLayer] = 
                        matrix[i][last];

                    // top -> right
                    matrix[i][last] = top;      // right <- saved top
                }
            }
        }
    }
}
