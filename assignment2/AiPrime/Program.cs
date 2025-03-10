using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiPrime
{
    class Program
    {
        static bool[] solution(int num)
        {
            if(num< 2)
            {
                throw new ArgumentException("输入数字必须大于一！");
            }   
            bool [] prime=new bool [num+1];//prime[i]为true表示i为素数  
            //初始化数组 
            for (int i = 2; i < prime.Length; i++)
            {
                prime[i]= true ;    
            }
            for(int i = 2; i < prime.Length; i++)
            {
                if (!prime[i])
                    continue;
                for (int j = i *i; j < prime.Length; j++)
                {
                    if (j%  i == 0)
                        prime[j] = false;
                }
            }
            return prime;   
        }   
        static void Main(string[] args)
        {
            bool []result= solution(100);  
            for(int i=2;i<result.Length;i++)
            {
                if(result[i])
                    Console.WriteLine(i);
            }   
        }
    }
}
