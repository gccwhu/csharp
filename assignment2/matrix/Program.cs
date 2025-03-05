using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class matrix
    {
        static bool solution(int[,] matrix)
        {
            int rows = matrix.GetLength(0)-1;
            int cols = matrix.GetLength(1)-1;
            for (int i = 0; i < cols; i++)
            {
                int j = 0,k=i;
                while (j<rows&&k<cols)
                {
                    if(matrix[j,k] == matrix[j + 1, k + 1]) {
                        j++;
                        k++;
                    }
                    else
                    {
                        return false;
                    }
                }   

            }
            for (int i = 0; i < rows; i++)
            {
                int j = i, k = 0;
                while (j < rows && k < cols)
                {
                    if (matrix[j, k] == matrix[j + 1, k + 1])
                    {
                        j++;
                        k++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }   
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 1, 2, 3,4 }, { 5, 1, 2,3 }, { 9,5, 1, 2 } };
            Console.WriteLine(solution(matrix));    
        }
    }
}
