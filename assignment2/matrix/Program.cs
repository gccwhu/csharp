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
            if(matrix == null)
                throw new ArgumentException("矩阵不能为空！"); 
            for(int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if ( matrix[i, j] != matrix[i - 1, j - 1])
                        return false;
                }
            }   
            return true;
        }   
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 2, 3,4 }, { 5, 1, 2,3 }, { 9,5, 1, 2 } };
            Console.WriteLine(solution(matrix));    
        }
    }
}
