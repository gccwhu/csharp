using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    class arraySum
    {
        static void solution(Array arr,out int max,out int min,out int ave,out int sum)
        {
            max = int.MinValue; min = int.MaxValue; ave = 0; sum=0;
            foreach (int i in arr )
            {
                sum += i;
                if (i > max)
                    max = i;
                if (i < min)
                    min = i;
            }
            ave=sum/ arr.Length;    
        }
        static void Main(string[] args)
        {
            int []a = { 11,32,23,14,57 };
            arraySum arr= new arraySum();
            solution(a, out int max, out int min, out int ave, out int sum);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Ave: " + ave);   
            Console.WriteLine("Sum: " + sum);
        }
    }
}
