using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Prime
    {  
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                    while (n % i == 0)
                    {
                        Console.WriteLine(i);
                        n = n / i;
                    }
                
            }   
        }
    }
}
