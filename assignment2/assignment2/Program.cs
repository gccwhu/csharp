using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Prime
    {
        //因数分解（连除法）
        private static List <int> Factorize(int num)
        {
            if(num < 2)
            {
                throw new ArgumentException("输入数字必须大于一！");  
            }
            List<int> factors = new List<int>();  
            //i为除数，若为素数因子则连除
            for (int i = 2; i*i <= num; i++)
            {
                while (num % i == 0)
                {
                    factors.Add(i);
                    num = num / i;
                }
            }
            if (num !=1)
            {
                factors.Add(num);
            }
            return factors;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            List<int> factors = Factorize(n);
            foreach (int factor in factors)
            {
                Console.WriteLine(factor);
            }
        }
    }
}
