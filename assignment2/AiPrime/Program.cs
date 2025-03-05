using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiPrime
{
    class Program
    {
        static int[,] solution(int n)
        {
            int [,] prime=new int [2,n-1];
            for (int i = 0; i < n-1; i++)
            {
                prime[0,i]= i + 2;    
            }
            for(int i = 0; i < n - 1; i++)
            {
                if (prime[1, i] == 1)
                {
                    continue;   
                }
                else
                {
                    for (int j = i+1; j < n - 1; j++)
                    {
                        if (prime[0, j] % prime[0, i] == 0)
                        {
                            prime[1, j] = 1;
                        }
                    }
                }
            }
            return prime;   
        }   
        static void Main(string[] args)
        {
            int[,]result= solution(100);  
            for(int i=0;i<99;i++)
            {
                if(result[1,i]==0)
                    Console.WriteLine(result[0,i]);
            }   
        }
    }
}
