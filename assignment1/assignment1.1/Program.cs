using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class assignment1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input an operator: ");
            string op = Console.ReadLine(); 
            switch (op) { 
                case "+":
                Console.WriteLine("The sum of the two numbers is: " + (num1 + num2));
                break;
            case "-":
                Console.WriteLine("The difference of the two numbers is: " + (num1 - num2));
                break;
            case "*":
                Console.WriteLine("The product of the two numbers is: " + (num1 * num2));
                break;
            case "/":
                Console.WriteLine("The quotient of the two numbers is: " + (num1 / num2));
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;  }
            }
    }
}
